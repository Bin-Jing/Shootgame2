using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosterAttaack : MonoBehaviour {

	public float timeBetweenAttacks = 1.0f;
	public int attackDamage = 3;

	GameObject player;
	CannonHealth playerHealth;
	EnemyHealth enemyHealth;
	Animator _animator;

	float timer = 0f;
	bool isAttacking = false;
	bool playerInRange = false;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <CannonHealth> ();
		enemyHealth = GetComponent<EnemyHealth>();
		_animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		isAttacking = false;
		if(timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0){
			Attack ();
		}
		_animator.SetBool ("Attack", isAttacking);

	}
		
	void OnTriggerEnter (Collider other){
		if(other.gameObject == player){
			playerInRange = true;

		}
	}
	void Attack(){
		timer = 0;
		if(playerHealth.currentHealth > 0){
			isAttacking = true;
			playerHealth.applyDamage (attackDamage);
			_animator.SetTrigger ("Respawn");
		}
	}
}
