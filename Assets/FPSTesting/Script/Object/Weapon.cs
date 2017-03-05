using Assets.FPSTesting.Object;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

public class Weapon : BringableObject {

    public float distance;
    public float damage;

    [SerializeField]
    public int ammo;
    [SerializeField]
    public int ammoMax;

    [SerializeField]
    public int inMag;


    [SerializeField]
    public int maxInMag;
    

    [SerializeField]
    public int fireCost;

    public float cooldown;

    private float lastShot;

    public Mesh mesh;


    // Use this for initialization
    void Start () {
        lastShot = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool CanShoot()
    {
        if(inMag - fireCost >= 0 && Time.time >= lastShot)
        {
            return true;
        }

        return false;
    }

    public override void Use(ref Player player)
    {
        lastShot = Time.time + cooldown;
        inMag -= fireCost;
    }

    public void Shoot()
    {
        inMag -= fireCost;
    }
}
