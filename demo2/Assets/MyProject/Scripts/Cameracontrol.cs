//设置摄像机的跟随

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontrol : MonoBehaviour {

	public GameObject player;	//确定跟随的对象
	private Vector3 cameraPosition;
	private Vector2 range=new Vector2(-3,106);
	public AudioClip[] au;
	public AudioClip[] p_au;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(GameManager.GameOver){
			return;
		}
		cameraPosition =new  Vector3(player.transform.position.x,transform.position.y,transform.position.z); 		
		cameraPosition=new Vector3(Mathf.Clamp(cameraPosition.x,range.x,range.y),transform.position.y,transform.position.z);
		transform.position=cameraPosition;
	}

	public void playSound(int id){
		GetComponent<AudioSource>().clip=au[id];//获取AudioSource面板，修改cilp音源
		GetComponent<AudioSource>().Play();
	}

	public void playerSound(int id){
		GetComponent<AudioSource>().clip=p_au[id];//获取AudioSource面板，修改cilp音源
		GetComponent<AudioSource>().Play();
	}	
}
