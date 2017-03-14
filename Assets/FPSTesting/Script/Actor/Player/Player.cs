using Assets.FPSTesting.Object;
using Assets.FPSTesting.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Player : Actor {

    public Camera weaponCamera;

    public Transform[] spawnPoints;

    public List<BringableObject> inventory;

    //indicates which object the user has in his hands, refers to the inventory
    private int objectInHand = 0;

    public List<AudioClip> fireShots;

    public GameManager gameManager;

    public List<AudioClip> painSounds;

	// Use this for initialization
	void Start () {

        Weapon weapon = (Weapon) inventory[objectInHand];

        gameManager.InitHUD(weapon.InMag, weapon.Ammo, weapon.name);
	}
	
	// Update is called once per frame
	void Update () {
       
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            if(inventory[objectInHand] is Weapon)
            {
                Weapon weapon = (Weapon) inventory[objectInHand];

                if (weapon.CanShoot())
                {
                    Player player = this;

                    weapon.Use(ref player);
                    gameManager.ShotFired(weapon.InMag, weapon.Ammo);
                    PlayRandomShotSound();
                }

            }
                  
        }
        else if(Input.GetKeyDown(KeyCode.Tab))
        {
            gameManager.ToggleInventory();
        }
        else if(Input.GetKeyDown(KeyCode.R))
        {
            if(inventory[objectInHand] is Weapon)
            {
                Weapon weapon = (Weapon)inventory[objectInHand];

                if(weapon.Reload())
                    gameManager.ShotFired(weapon.InMag, weapon.Ammo);
            }
        }
		
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
        AudioSource.PlayClipAtPoint(painSounds[Random.Range(0, painSounds.Count)], transform.position);

        return base.TakeDamage(damage);
    }
}