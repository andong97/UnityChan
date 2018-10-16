using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameContorl : MonoBehaviour {

	private float speed=8f;
	private float jump=25f;
	private bool jumping;
	private int hp=2;
	private Rigidbody2D body;
	private Animator animator;
	
	// public Transform headpoint;//设置头顶的碰撞点
	// public float headradius;//头顶碰撞检测半径
	// public LayerMask blocklayer;//碰撞检测层
	// public bool isbrokenblock;
	public Transform groundpoint1;//设置检测对象1
	public Transform groundpoint2;//设置检测对象2
	public float groundradius;//设置检测半径1

	public LayerMask groundlayer;//设置碰撞检测层
	private bool isTuochgroundcheck;
	private bool damage=false;//判断角色是否受伤
	private AnimatorStateInfo state;//用来获取当前动画机的状态信息
	private bool stateblock;
	private bool Finish;
	
	// Use this for initialization

	void Awake(){//awake是一种比start调用更早的函数
		// animator=GetComponent<Animator>();
		// body=GetComponent<Rigidbody2D>();
	}

	void FixedUpdate(){//适用于高速移动的情况

	}

	void Start () {
		animator=GetComponent<Animator>();
		body=GetComponent<Rigidbody2D>();
		FindObjectOfType<Cameracontrol>().playSound(3);
	}
	
	// Update is called once per frame
	void Update () {
		if(!damage&&Statelock()&&!Finish){
			Move();
			Jump();
		}
		// if (Finish){
		// 	body.velocity=new Vector2(0,body.velocity.y);
		// }
		StateMachineBehaviour();
		setJumpState();
	}

	void Move(){
		float moovement=Input.GetAxis("move");
			if(moovement>0f){
				body.velocity=new Vector2(moovement*speed,body.velocity.y);
				transform.localScale=new Vector2(1,1);
			}else if(moovement<0f){
				body.velocity=new Vector2(moovement*speed,body.velocity.y);
				transform.localScale=new Vector2(-1,1);
			}else{
				body.velocity=new Vector2(0,body.velocity.y);
			}
	
	}
	protected internal void Ondamage(){
		damage=true;
		animator.SetTrigger("Damage");
		FindObjectOfType<Cameracontrol>().playerSound(4);
		hp-=1;
		 if(hp<0){
			 FindObjectOfType<Cameracontrol>().playerSound(3);
		 	Gameover();
		 }
	}

	void Gameover(){
		body.velocity=new Vector2(0,body.velocity.y);
		animator.SetTrigger("Over");
		GameManager.GameOver=true;
		GameManager.life-=1;
		// Debug.Log("coming");
		StartCoroutine("loadlevel");
		// Debug.Log("out");		
	}
	IEnumerator loadlevel(){
		// Debug.Log("in");
		yield return new WaitForSeconds(2.5f);
		// Debug.Log("loading");
		Application.LoadLevel(1);
	}
	void endamage(){
		damage=false;
	}
	void setJumpState(){
		if(body.velocity.y>0.1){
			jumping=true;
		}else if(body.velocity.y<0.1){
			jumping=false;
		}
	}
	void StateMachineBehaviour(){
		if(Input.GetKeyDown(KeyCode.J)&&isTuochgroundcheck){
			animator.SetInteger("attack",animator.GetInteger("attack")+1);
			body.velocity=new Vector2(0,body.velocity.y);
			if(animator.GetInteger("attack")==1){
				FindObjectOfType<Cameracontrol>().playerSound(1);
			}
		}
		animator.SetFloat("speed",Mathf.Abs(body.velocity.x));
		animator.SetBool("jumping",jumping);
		animator.SetBool("onGround",isTuochgroundcheck);
		state=animator.GetCurrentAnimatorStateInfo(0);
	}

	bool Statelock(){
		return !state.IsTag("lock");
	}

	void Jump(){
		isTuochgroundcheck=Physics2D.OverlapCircle(groundpoint1.position,groundradius,groundlayer)||Physics2D.OverlapCircle(groundpoint2.position,groundradius,groundlayer);
		if(Input.GetKeyDown(KeyCode.Space)&&isTuochgroundcheck){
			FindObjectOfType<Cameracontrol>().playerSound(0);
			body.velocity=new Vector2(body.velocity.x,jump);
		}
	}
	void scale(){
		// GetComponentInChildren<Transform>().localScale=new Vector3(1,1,1);
	}
	void attacksound(){
		FindObjectOfType<Cameracontrol>().playerSound(1);
	}

	// void OnTriggerEnter2D(Collider2D other){
	// 	if(other.tag=="FinishCheck"){
	// 		animator.SetBool("Finish",true);
	// 		Finish=true;
	// 		FindObjectOfType<Cameracontrol>().playerSound(2);
	// 	}
	// }
}
