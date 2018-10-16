using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour {
	public Text t_life;
	public Text t_score;
	public Text t_coin;
	private string s_zero="0000000";
	private string c_zero="00";

	// Use this for initialization
	void Start () {
		t_life.text=GameManager.life.ToString();
		t_coin.text=" "+"X"+" "+c_zero.Substring(0,c_zero.Length-GameManager.coins.ToString().Length)+GameManager.coins;
		t_score.text=s_zero.Substring(0,s_zero.Length-GameManager.score.ToString().Length)+GameManager.score.ToString();
		Invoke("StartGame",3);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void StartGame(){
		GameManager.GameOver=false;	
		Application.LoadLevel("Stage1");
	}
}
