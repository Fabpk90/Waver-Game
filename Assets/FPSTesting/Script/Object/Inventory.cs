using Assets.FPSTesting.Object;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    private int indexObjectHand = 0;

    public List<BringableObject> inventory;

    public GameObject HandPosition;

	// Use this for initialization
	void Start () {
        populateList();

      //  inventory[indexObjectHand].GetComponent<Renderer>().enabled = true;
	}

    private void populateList()
    {
        BringableObject objectInInv;

        for(int i = 0; i < inventory.Count; ++i)
        {
            objectInInv = Instantiate<BringableObject>(inventory[i], HandPosition.transform);

           // objectInInv.GetComponent<BringableObject>().mesh. = false;
            inventory[i] = objectInInv;

        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// tries to get the less 1 object in the hand of the player, goes back if out of range
    /// </summary>
    public void backwardObject()
    {
        indexObjectHand--;
        if (indexObjectHand < 0)
            indexObjectHand = inventory.Count - 1;
    }

    /// <summary>
    /// Gets the next object in the inventory, goes back to the beginning if out of range
    /// </summary>
    public void towardObject()
    {
        indexObjectHand = (indexObjectHand + 1) % inventory.Count - 1;
    }

    public bool setIndex(int index)
    {
        if(index > 0 && index < inventory.Count)
        {
            indexObjectHand = index;
            return true;
        }

        return false;
    }

    public BringableObject getObjectInHand()
    {
        return inventory[indexObjectHand];
    }
}
