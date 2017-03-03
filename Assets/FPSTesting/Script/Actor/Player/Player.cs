using Assets.FPSTesting.Object;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Player : Actor {

    public Weapon weapon;
    public Camera weaponCamera;

    public Transform[] spawnPoints;

    public List<BringableObject> inventory;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
       
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
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
    }

    override public void Dying()
    {
        transform.position = GetRandomSpawnPoint();
    }

    private Vector3 GetRandomSpawnPoint()
    {
        return spawnPoints[Random.Range(0, spawnPoints.Length)].position;
    }
}