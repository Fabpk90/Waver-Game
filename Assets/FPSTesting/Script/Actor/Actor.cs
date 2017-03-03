using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actor : MonoBehaviour {

    public bool isPlayer;

    public float health;
    public float maxHealth;

    public float attackDamage;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="damage"></param>
    /// <returns>true if dead</returns>
    virtual public bool TakeDamage(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Dying();

            return true;
        }

        return false;

    }

    virtual public bool Attack(ref Actor actor, float damage)
    {
         return actor.TakeDamage(damage);
    }

    virtual public void GiveHealth(int amount)
    {
        if (health + amount >= maxHealth)
            health = maxHealth;

        health += amount;
    }
    public abstract void Dying();
}
