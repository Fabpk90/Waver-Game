using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToAttackBehaviour : MonoBehaviour {

    private Actor actorToChase = null;

    private float attack;


    private void Start()
    {
        attack = GetComponent<Actor>().attackDamage;
    }

    // Update is called once per frame
    void Update () {

        if (actorToChase != null)
            MoveTo(actorToChase.gameObject);
        else
        {

        }
        
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Player>() != null)
        {
            actorToChase = other.GetComponent<Player>();
            Debug.Log("qsd");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.GetComponent<Player>() != null)
        {
            Player player = collision.collider.GetComponent<Player>();
            player.TakeDamage(attack);
        }
    }

    private void OnCollisionExit(Collision collision)
    {

    }



    private void MoveTo(GameObject obj)
    {
       transform.position = Vector3.MoveTowards(transform.position, obj.transform.position, 0.05f);
    }
}
