using Assets.FPSTesting.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    private Text timerUI;

	// Use this for initialization
	void Start () {
        timerUI = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {

        timerUI.text = "" + Mathf.Floor(GameManager.timeElapsed);
	}
}
