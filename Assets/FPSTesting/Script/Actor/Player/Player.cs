using Assets.FPSTesting.Object;
using Assets.FPSTesting.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Player : Actor {

    public int money;

    public Camera weaponCamera;

    public Transform[] spawnPoints;

    public Inventory inventory;

    //indicates which object the user has in his hands, refers to the inventory
    private int objectInHand = 0;

    public List<AudioClip> fireShots;

    public GameManager gameManager;

    public List<AudioClip> painSounds;

    private int lastTimeSoundPlayed;

	// Use this for initialization
	void Start () {

        lastTimeSoundPlayed = 0;

        Weapon weapon = (Weapon) inventory.getObjectInHand();

        gameManager.InitHUD(weapon.InMag, weapon.Ammo, weapon.name);
	}
	
	// Update is called once per frame
	void Update () {
       
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            if(inventory.getObjectInHand() is Weapon)
            {
                Weapon weapon = (Weapon)inventory.getObjectInHand();

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
            if(inventory.getObjectInHand() is Weapon)
            {
                Weapon weapon = (Weapon)inventory.getObjectInHand();

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
        //if the last time is < than the time.tim then you can play the sound
        if(Time.time >= lastTimeSoundPlayed)
        {
            AudioClip sound = painSounds[Random.Range(0, painSounds.Count)];
            AudioSource.PlayClipAtPoint(sound, transform.position);

            lastTimeSoundPlayed = (int) ( Time.time + sound.length );

        }
        

        return base.TakeDamage(damage);
    }
}