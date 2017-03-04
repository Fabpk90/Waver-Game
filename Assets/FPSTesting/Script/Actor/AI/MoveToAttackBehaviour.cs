using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToAttackBehaviour : MonoBehaviour {

    private Actor actorToChase = null;
    private SphereCollider sphereCollider;


    private void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update () {

        if (actorToChase != null)
            MoveTo(actorToChase.gameObject);
        
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
        Vector3.MoveTowards(transform.position, obj.transform.position, sphereCollider.radius);
    }
}
