using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UFOScript : MonoBehaviour {
	LineRenderer laserShotLine;
	Transform player;
	UnityEngine.AI.NavMeshAgent nav;
	CannonHealth playerHealth;
	public float startingHealth = 200;
	public float currentHealth;
	public int scoreValue = 10;
	public float sinkSpeed = 2.5f;
	public Image healthBar;
	public GameObject DeadExplosion;
	public AudioClip[] deathAudio;
	public float stopDistance = 20f;
	public int damage = 1;
	public AudioClip shootAudio;

	AudioSource audioSource;
	AudioClip deathClip;
	float timer = 0f;

	bool isDead;

	void Awake (){
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
		playerHealth = player.GetComponent<CannonHealth> ();
		laserShotLine = GetComponentInChildren<LineRenderer> ();
		currentHealth = startingHealth;
		audioSource = gameObject.GetComponent<AudioSource> ();
	}


	void Update (){
		if(isDead){
			transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
		}
		timer += Time.deltaTime;
		if (currentHealth > 0 && playerHealth.currentHealth > 0 ) {
			nav.SetDestination (player.position);
			if (nav.remainingDistance < stopDistance) {
				if (timer > 0.5f) {
					Attack ();
					timer = 0;
				}

			} else {
				laserShotLine.enabled = false;
			}

		}else{
			nav.enabled = false;
			laserShotLine.enabled = false;
		}

	}

	void Death (){
		isDead = true;

		Destroy(Instantiate (DeadExplosion, this.transform.position, this.transform.rotation),1f);
		GameObject.Find ("GameManager").GetComponent<GameManager> ().addScore (scoreValue);
		int index = Random.Range (0, deathAudio.Length);
		deathClip = deathAudio [index];
		audioSource.clip = deathClip;
		audioSource.Play ();
		Destroy (gameObject, 4f);


	}
	public void applyDamage(int damage){
		if(isDead)
			return;
		currentHealth -= damage;
		healthBar.fillAmount = currentHealth / startingHealth;
		if(currentHealth <= 0){
			Death ();
		}
	}

	void Attack(){
		playerHealth.applyDamage (damage);
		ShotEffect ();

	}
	void ShotEffect(){
		audioSource.PlayOneShot (shootAudio);
		laserShotLine.SetPosition (0, laserShotLine.transform.position);
		laserShotLine.SetPosition (1, player.position + Vector3.up * 1.5f);
		laserShotLine.enabled = true;
	}
}
