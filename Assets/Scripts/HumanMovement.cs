using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMovement : MonoBehaviour {

	Transform player;
	UnityEngine.AI.NavMeshAgent nav;
	EnemyHealth enemyHealth;
	CannonHealth playerHealth;
	Animator _animator;
	bool isRunning = true;
	bool isAttacking = false;
	public float stopDistance = 20f;
	void Awake (){
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
		enemyHealth = GetComponent <EnemyHealth> ();
		_animator = GetComponent<Animator> ();
		playerHealth = player.GetComponent<CannonHealth> ();
	}


	void Update (){
		isAttacking = false;
		if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 ) {
			isRunning = true;
			nav.SetDestination (player.position);
			if (nav.remainingDistance < stopDistance) {
				isRunning = false;
				isAttacking = true;
			}
		}else{
			nav.enabled = false;
			isRunning = false;

			_animator.SetTrigger ("Respawn");
		}
		_animator.SetBool ("Running", isRunning);
		_animator.SetBool("Attack",isAttacking);
	}
}
