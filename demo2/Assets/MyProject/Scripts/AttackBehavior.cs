using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehavior : StateMachineBehaviour {
	public float transhold=1;
	public int order=0;
	void OnStateUpdate(Animator animator,AnimatorStateInfo info,int id){
		if(info.normalizedTime<=transhold){//当动画播放进度小于transhold的值，就将attack一直设置为order的值
			animator.SetInteger("attack",order);
		}
	}

	void OnStateExit(Animator animator,AnimatorStateInfo info,int id){
		animator.SetInteger("attack",0);
		}
}
