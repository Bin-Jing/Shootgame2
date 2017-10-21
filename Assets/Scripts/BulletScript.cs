using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	public GameObject Bullet;
	public GameObject FireLight;

	float coldtime = 1;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		coldtime += Time.deltaTime;
		if (Input.GetButtonDown ("Fire2") && coldtime > 0.05) {
			
			Destroy(Instantiate (Bullet, this.transform.position, this.transform.rotation),5);
			Destroy(Instantiate (FireLight, this.transform.position, this.transform.rotation),1f);
			coldtime = 0;

		}
	}
}
