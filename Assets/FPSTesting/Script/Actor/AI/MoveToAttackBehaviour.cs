using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToAttackBehaviour : MonoBehaviour {

    private Actor actorToChase = null;

    private bool isColliding = false;

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

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.GetComponent<Player>() != null)
        {
            isColliding = false;
        }
    }



    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.GetComponent<Player>() != null)
        {
            isColliding = true;
        }
    }




    private void MoveTo(GameObject obj)
    {
       transform.position = Vector3.MoveTowards(transform.position, obj.transform.position, 0.05f);
    }
}
