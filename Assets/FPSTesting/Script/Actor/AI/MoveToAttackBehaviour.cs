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
            //search for enemies
        }
        
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Player>() != null)
        {
            actorToChase = other.GetComponent<Player>();
        }
    }


    private void MoveTo(GameObject obj)
    {
       transform.position = Vector3.MoveTowards(transform.position, obj.transform.position, 0.05f);
    }
}
