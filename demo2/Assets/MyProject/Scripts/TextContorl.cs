using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextContorl : MonoBehaviour {
	private Text t;
	// Use this for initialization
	void Start () {
		InvokeRepeating("showText",0,0.5f);//0秒之后每隔0.5秒执行一次函数
		t=GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void showText(){
		if(t.text==""){
			t.text="按下 X 开始";
		}else{
			t.text="";
		}
	}
}
