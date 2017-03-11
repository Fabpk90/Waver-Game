using Assets.FPSTesting.Object;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

public class Weapon : BringableObject {

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
    }


    public bool CanShoot()
    {
        if(InMag - fireCost >= 0 && Time.time >= lastShot)
        {
            return true;
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
}
