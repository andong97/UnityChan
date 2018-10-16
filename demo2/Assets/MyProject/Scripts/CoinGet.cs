using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGet : MonoBehaviour {
	private bool getten=false;
	private int coinNum=1;
	private int coinScore=100;
	private CoinNum gameobject;
	// Use this for initialization
	void Start () {
		gameobject=FindObjectOfType<CoinNum>();
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag!="Player"||getten){
			return;
		}
		GetComponent<Animator>().Play("Coindamp");
		getten=true;
		gameobject.getCoin(coinNum);
		FindObjectOfType<Cameracontrol>().playSound(2);
		GameManager.coins+=1;
		FindObjectOfType<ScoreContorl>().scoreContorl(coinScore);
	}
	void Getten(){
		Destroy(this.gameObject);
		
	}
	
}
