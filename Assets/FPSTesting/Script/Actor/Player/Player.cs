using Assets.FPSTesting.Object;
using Assets.FPSTesting.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Player : Actor {

    public Weapon weapon;
    public Camera weaponCamera;

    public Transform[] spawnPoints;

    public List<BringableObject> inventory;

    public List<AudioClip> fireShots;

    public GameManager gameManager;

	// Use this for initialization
	void Start () {
        gameManager.InitHUD(weapon.inMag, weapon.ammo, weapon.description);
	}
	
	// Update is called once per frame
	void Update () {
       
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(weapon.CanShoot())
            {
                Shoot();
                gameManager.ShotFired(weapon.inMag, weapon.ammo);
            }         
        }
        else if(Input.GetKeyDown(KeyCode.Tab))
        {
            gameManager.ToggleInventory();
        }
		
	}

    private void Shoot()
    {    
        RaycastHit hit;

        //the ray position (center of the camera)
        Vector3 rayOrigin = weaponCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));


        if (Physics.Raycast(rayOrigin, weaponCamera.transform.forward, out hit, weapon.distance))
        {       
            if(hit.collider.GetComponent<EnemyController>() != null)
            {
                hit.rigidbody.AddForce(-hit.normal * weapon.damage);

                EnemyController enemy = hit.collider.GetComponent<EnemyController>();

                enemy.TakeDamage(weapon.damage);
            }
        }

        PlayRandomShotSound();
        weapon.Shoot();
    }

    private void PlayRandomShotSound()
    {
        AudioSource.PlayClipAtPoint(fireShots[Random.Range(0, fireShots.Count)], transform.position);
    }

    override public void Dying()
    {
        transform.position = GetRandomSpawnPoint();
    }

    private Vector3 GetRandomSpawnPoint()
    {
        return spawnPoints[Random.Range(0, spawnPoints.Length - 1)].position;
    }

    public override bool TakeDamage(float damage)
    {
        Debug.Log("damage: " + damage);

        return base.TakeDamage(damage);
    }
}