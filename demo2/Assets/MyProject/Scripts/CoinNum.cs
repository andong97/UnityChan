using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoinNum : MonoBehaviour {
	public int Coins;
	private string c_zero="00";

	// Use this for initialization
	void Start () {
		GetComponent<Text>().text=" "+"X"+" "+c_zero.Substring(0,c_zero.Length-GameManager.coins.ToString().Length)+GameManager.coins;
		Coins=GameManager.coins;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void getCoin(int CoinsValue){
		Coins+=CoinsValue;
		if(Coins>9){
			GetComponent<Text>().text=" "+"X"+" "+Coins;
		}else{
			GetComponent<Text>().text=" "+"X"+" 0"+Coins;
		}
	}
}
