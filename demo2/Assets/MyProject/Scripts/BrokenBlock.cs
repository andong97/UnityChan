using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenBlock : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D(Collision2D other){
		// Debug.Log("collision");
		if(other.gameObject.tag=="Player" && other.contacts[0].normal == Vector2.up){
			FindObjectOfType<Cameracontrol>().playSound(0);
			Instantiate(Resources.Load("BrokenBlock"),transform.position,transform.rotation);
			Destroy(gameObject);
		}
	}
}
