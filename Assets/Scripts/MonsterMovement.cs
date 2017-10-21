using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class MonsterMovement : MonoBehaviour
{
	Transform player;
	UnityEngine.AI.NavMeshAgent nav;
	EnemyHealth enemyHealth;
	Animator _animator;
	bool isRunning = true;
	void Awake (){
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
		enemyHealth = GetComponent <EnemyHealth> ();
		_animator = GetComponent<Animator> ();
	}


	void Update (){
		if (enemyHealth.currentHealth > 0) {
			_animator.SetBool ("Running", isRunning);
			nav.SetDestination (player.position);
		}else{
			nav.enabled = false;
		}
	}
}
