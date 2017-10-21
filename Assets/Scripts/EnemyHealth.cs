using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
	
	public int startingHealth = 100;
	public int currentHealth;
	public int scoreValue = 10;
	public float sinkSpeed = 2.5f;

	Animator _animator;

	bool isDead;
	bool isSinking;
	bool gettingHit = false;

	void Awake (){
		_animator = GetComponent <Animator> ();

		currentHealth = startingHealth;
	}


	void Update (){
		if(isSinking){
			transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
		}
		_animator.SetBool ("GetHit", gettingHit);
		gettingHit = false;


	}

	//the function must public ,because it will be call by animation event and you need to set it by yourself
	public void StartSinking (){
		GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;
		GetComponent <Rigidbody> ().isKinematic = true;
		isSinking = true;
		Destroy (gameObject, 2f);
	}

	void Death ()
	{
		isDead = true;

		_animator.SetTrigger ("Dead");

	}
	public void applyDamage(int damage,float hitback){
		if(isDead)
			return;
		gettingHit = true;
		currentHealth -= damage;
		transform.position -= new Vector3 (hitback, 0, 0);
		_animator.SetTrigger("Respawn");
		if(currentHealth <= 0){
			Death ();
		}
	}

}
