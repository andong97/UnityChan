using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeContol : MonoBehaviour {
	private int timeMax=120;
	private int currentTime;
	// Use this for initialization
	void Start () {
		currentTime=timeMax;
		InvokeRepeating("timeContol",0,1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void timeContol(){
		currentTime-=1;
		GetComponent<Text>().text=currentTime.ToString();
	}
}
