using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToAttackBehaviour : MonoBehaviour {

    public Actor actorToChase;
    private SphereCollider sphereCollider;


    private void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update () {

        //transform.position = Vector3.MoveTowards(transform.position, actorToChase.transform.position, 10.0f);
        
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Player>() != null)
        {

        }
    }



    private void MoveTo(GameObject obj)
    {
        Vector3.MoveTowards(transform.position, obj.transform.position, sphereCollider.radius);
    }
}
