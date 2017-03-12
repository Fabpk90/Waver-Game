using Assets.FPSTesting.Object;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;
using Assets.FPSTesting.Script.Utils;

public class Weapon : BringableObject {

    public List<AudioClip> reloadSounds;
    public List<AudioClip> emptyMagSounds;

    public float distance;
    public float damage;

    
    private int ammo; 
    public int ammoMax;

  
    private int inMag;
    public int maxInMag;
    
    
    public int fireCost;

    public float cooldown;

    private float lastShot;

    public Mesh mesh;

    private bool IsReloading;

    public int InMag
    {
        get
        {
            return inMag;
        }

        set
        {
            inMag = value;
        }
    }

    public int Ammo
    {
        get
        {
            return ammo;
        }

        set
        {
            ammo = value;
        }
    }


    // Use this for initialization
    void Start () {
        lastShot = 0;

        Ammo = ammoMax;
        InMag = maxInMag;

        IsReloading = false;
    }


    public bool CanShoot()
    {
        if(IsReloading)
        {
            return false;
        }
        else if(InMag - fireCost >= 0 && Time.time >= lastShot)
        {
            return true;
        }
        else
        {
            playRandomSoundFromList(emptyMagSounds);
        }

        return false;
    }

    public override void Use(ref Player player)
    {
        lastShot = Time.time + cooldown;
        InMag -= fireCost;

        Shoot(player);
    }

    public void Shoot(Player player)
    {    
        RaycastHit hit;
        Camera weaponCamera = player.GetComponentInChildren<Camera>();

        //the ray position (center of the camera)
        Vector3 rayOrigin = weaponCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));


        if (Physics.Raycast(rayOrigin, weaponCamera.transform.forward, out hit, distance))
        {
            if (hit.collider.GetComponent<EnemyController>() != null)
            {
                hit.rigidbody.AddForce(-hit.normal * damage);

                EnemyController enemy = hit.collider.GetComponent<EnemyController>();

                enemy.TakeDamage(damage);
            }
        }
    }

    public bool Reload()
    {
        if(!IsReloading)
        {     
            if(ammo != 0)
            {
                Invoke("ReloadFinished", playRandomSoundFromList(reloadSounds).length);

                IsReloading = true;

                ammo += inMag;
                inMag = 0;

                if(ammo >= maxInMag)
                {
                    ammo -= maxInMag;
                    inMag = maxInMag;
                }
                else
                {
                    inMag = ammo;
                    ammo = 0;
                }

                return true;
            }          
        }

        return false;
    }

    private void ReloadFinished()
    {
        IsReloading = false;
    }

    private AudioClip playRandomSoundFromList(List<AudioClip> sounds)
    {
        AudioClip sound = ListUtil<AudioClip>.getRandomElement(sounds);

        AudioSource.PlayClipAtPoint(sound, transform.position);

        return sound;
    }
}
