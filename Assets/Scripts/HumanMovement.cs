using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMovement : MonoBehaviour {
	LineRenderer laserShotLine;
	Transform player;
	UnityEngine.AI.NavMeshAgent nav;
	EnemyHealth enemyHealth;
	CannonHealth playerHealth;
	Animator _animator;


	bool isRunning = true;
	bool isAttacking = false;
	float timer = 1f;

	public float stopDistance = 20f;
	public int damage = 1	;

	void Awake (){
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
		enemyHealth = GetComponent <EnemyHealth> ();
		_animator = GetComponent<Animator> ();
		playerHealth = player.GetComponent<CannonHealth> ();
		laserShotLine = GetComponentInChildren<LineRenderer> ();

		laserShotLine.enabled = false;
	}


	void Update (){
		isAttacking = false;
		timer += Time.deltaTime;
		if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 ) {
			isRunning = true;
			nav.SetDestination (player.position);
			if (nav.remainingDistance < stopDistance) {
				isRunning = false;
				if (timer > 0.5f) {
					Attack ();
					timer = 0;
				}

			} else {
				laserShotLine.enabled = false;
			}

		}else{
			nav.enabled = false;
			isRunning = false;
			laserShotLine.enabled = false;
			_animator.SetTrigger ("Respawn");
		}
		_animator.SetBool ("Running", isRunning);
		_animator.SetBool("Attack",isAttacking);

		if (playerHealth.currentHealth <= 0) {
			_animator.SetTrigger ("Victory");
		}

	}
	void OnAnimatorIK(int layerIndex){
		_animator.SetIKPosition (AvatarIKGoal.RightHand, player.position +
		Vector3.up);
	}
	void Attack(){
		isAttacking = true;
		playerHealth.applyDamage (damage);
		ShotEffect ();

	}
	void ShotEffect(){
		laserShotLine.SetPosition (0, laserShotLine.transform.position);
		laserShotLine.SetPosition (1, player.position + Vector3.up * 1.5f);
		laserShotLine.enabled = true;
	}
}
