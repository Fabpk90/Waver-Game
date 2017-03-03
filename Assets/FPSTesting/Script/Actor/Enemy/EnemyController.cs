﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Actor
{

    public ParticleSystem dieParticle;
    public ParticleSystem damageParticle;

    [SerializeField]
    private float cooldownAttack;

    private float lastAttack;

	// Use this for initialization
	void Start () {
        lastAttack = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Actor>() != null)
        {
            Actor actor = other.GetComponent<Actor>();
            if (CanAttack() && actor.isPlayer)
            {
                Attack(ref actor, attackDamage);
            }
        }
    }

    private bool CanAttack()
    {
        return Time.time >= lastAttack + cooldownAttack ? true : false;
    }

    public override bool TakeDamage(float damage)
    {
        Instantiate(damageParticle, this.gameObject.transform.position, Quaternion.identity);
        return base.TakeDamage(damage);
    }

    public override void Dying()
    {
        if(dieParticle != null)
            Instantiate(dieParticle, this.gameObject.transform.position, Quaternion.identity);

        Destroy(this.gameObject);
    }

}
