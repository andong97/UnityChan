using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContorl : MonoBehaviour {
	private int HairBallScore=200;//怪物的分数
	private float speed=2;//怪物移动的速度
	private float player_position;//获取player的坐标
	private bool incamera=true;//是否在摄像机内
	private bool attacked=false;//是否攻击到了玩家
	private float camera_position;//获取摄像机的坐标
	public Transform roycast;//射线检测点
	public float groundradius;//设置检测半径1

	public LayerMask groundlayer;//设置碰撞检测层
	
	
	
	// Use this for initialization

	//   OnBecameInvisible(){
	// 	if(this.GetComponent<Transform>().position.x>camera_position+20){
	// 		transform.Translate(Vector3.right*0*Time.deltaTime);
	// 	 	Debug.Log("不在摄像机里");
	// 		return;
	// 	}
	//   }
	void Start () {
		camera_position= GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>().position.x;
		if(this.GetComponent<Transform>().position.x>camera_position+20){
			transform.Translate(Vector3.right*0*Time.deltaTime);
			incamera=false;
		 	// Debug.Log("不在摄像机里");
		}
	}
	void inCamera(){ //判断是否在摄像机内
		if(this.GetComponent<Transform>().position.x<camera_position+20){
			incamera=true;
			return;
		}
	}
	

	// Update is called once per frame
	void Update () {
		player_position= GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position.x;//获取玩家位置
		camera_position= GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>().position.x;//获取摄像机位置
		if(GameManager.GameOver){
			return;
		}
		inCamera();
		if(!attacked && incamera==true){
			if((this.GetComponent<Transform>().position.x<player_position)){
				if(!Raycast()){
					transform.Translate(Vector3.right*speed*Time.deltaTime);
			 		transform.localScale=new Vector2(-1.795825f,1.795825f);
			 		incamera=true;
				}else{
					transform.Translate(Vector3.right*0*Time.deltaTime);
			 		transform.localScale=new Vector2(-1.795825f,1.795825f);
			 		incamera=true;
				}
			}else{
				if(!Raycast()){
					transform.Translate(Vector3.left*speed*Time.deltaTime);
			 		transform.localScale=new Vector2(1.795825f,1.795825f);
			 		incamera=true;
				}else{
					transform.Translate(Vector3.left*0*Time.deltaTime);
			 		transform.localScale=new Vector2(1.795825f,1.795825f);
			 		incamera=true;
				}
			}
			// if(this.GetComponent<Transform>().position.x<player_position){
			// 	 transform.Translate(Vector3.right*speed*Time.deltaTime);
			// 	 transform.localScale=new Vector2(-1.795825f,1.795825f);
			// 	 incamera=true;
			// 	// Debug.Log("rigthway");
			// }else{
			// 	transform.Translate(Vector3.left*speed*Time.deltaTime);
			// 	 transform.localScale=new Vector2(1.795825f,1.795825f);
			// 	 incamera=true;
			// 	// Debug.Log("leftway");
			//}
		}
	}
	 void OnCollisionEnter2D(Collision2D other){
		 //如果玩家在怪物上面
		 if(other.gameObject.tag=="Player"&&other.contacts[0].normal==Vector2.down){//每一个接触（contact）包含一个接触点、法线和两个碰撞的碰撞器（看ContactPoint）
			  Destroy(this.gameObject);
			  FindObjectOfType<ScoreContorl>().scoreContorl(HairBallScore);
			//Debug.Log("enemy");
		 }
		 //如果玩家正后面碰到怪物
		if(other.gameObject.tag=="Player"&&(other.contacts[0].normal==Vector2.left||other.contacts[0].normal==Vector2.right)){
			//  other.gameObject;
			//Debug.Log("enemy");
			other.rigidbody.AddForce(-other.contacts[0].normal*20);//给怪物碰到的玩家一个相反的数值为20的力
			attacked=true;
			Invoke("contiuneMove",0.8f);
			FindObjectOfType<GameContorl>().Ondamage();			
		}
		
	 }
	  void contiuneMove(){
		  attacked=false;
	  }
	 void OnTriggerEnter2D(Collider2D other){
	 	if(other.gameObject.tag=="DamageObject"){
	 		Destroy(this.gameObject);
	 	}
	  }

	  bool Raycast (){//怪物的碰到障碍物检测
	    return Physics2D.OverlapCircle(roycast.position,groundradius,groundlayer);
	  }
}
