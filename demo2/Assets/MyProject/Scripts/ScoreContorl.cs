using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreContorl : MonoBehaviour {
	private string zero="0000000";
	private int Score;
	// Use this for initialization
	void Start () {
		GetComponent<Text>().text=zero.Substring(0,zero.Length-GameManager.score.ToString().Length)+GameManager.score.ToString();
		Score=GameManager.score;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void scoreContorl(int score){
		Score+=score;
		GameManager.score=Score;
		GetComponent<Text>().text=zero.Substring(0,zero.Length-Score.ToString().Length)+Score.ToString();
	}
}
