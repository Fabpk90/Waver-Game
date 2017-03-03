using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemDestroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, GetComponent<ParticleSystem>().main.duration);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
