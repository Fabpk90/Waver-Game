using Assets.FPSTesting.Object;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : BringableObject {

    public float distance;
    public float damage;

    public uint ammo;
    public int ammoMax;

    public uint inMag;
    public int maxInMag;

    public int fireCost = 1;

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
        lastShot = Time.time;
        inMag -= (uint)fireCost;
    }
}
