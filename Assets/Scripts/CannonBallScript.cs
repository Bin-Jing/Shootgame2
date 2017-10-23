using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallScript : MonoBehaviour {

	public GameObject CannonBall;
	public GameObject FireLight;
	AudioSource Fireaudio;
	float coldtime = 1;
	// Use this for initialization
	void Start () {
		Fireaudio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		coldtime += Time.deltaTime;
		if (Input.GetButtonDown ("Fire1") && coldtime > 1) {
			Destroy(Instantiate (CannonBall, this.transform.position, this.transform.rotation),5);
			Destroy(Instantiate (FireLight, this.transform.position, this.transform.rotation),1f);
			Fireaudio.Play ();
			coldtime = 0;

		}
	}

}
