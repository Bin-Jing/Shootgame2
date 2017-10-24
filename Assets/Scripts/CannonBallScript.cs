using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallScript : MonoBehaviour {

	public GameObject CannonBall;
	public GameObject FireLight;
	AudioSource FireAudio;
	CannonHealth playerHealth;
	GameObject player;
	float coldtime = 1;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		FireAudio = GetComponent<AudioSource> ();
		playerHealth = player.GetComponent <CannonHealth> ();
	}
	
	// Update is called once per frame
	void Update () {
		coldtime += Time.deltaTime;
		if (Input.GetButtonDown ("Fire1") && coldtime > 1 && playerHealth.currentHealth > 0) {
			Destroy(Instantiate (CannonBall, this.transform.position, this.transform.rotation),5);
			Destroy(Instantiate (FireLight, this.transform.position, this.transform.rotation),1f);
			FireAudio.Play ();
			coldtime = 0;

		}
	}

}
