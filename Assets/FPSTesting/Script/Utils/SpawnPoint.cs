using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    public float cooldown;

    public bool IsUsed;

    private float timeLastUse;

	// Use this for initialization
	void Start () {
        IsUsed = false;
	}

    private void FixedUpdate()
    {
        if(IsUsed)
        {
            if(timeLastUse <= Time.time)
            {
                IsUsed = false;
                timeLastUse = Time.time;
            }
        }
    }

    public void Use()
    {
        IsUsed = true;
    }
}
