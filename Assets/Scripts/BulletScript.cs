using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	public GameObject Bullet;
	public GameObject FireLight;

	float coldtime = 1;
	bool isFire = false;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		coldtime += Time.deltaTime;
		if (Input.GetButtonDown ("Fire2") && coldtime > 0.01) {
			isFire = true;
			coldtime = 0;

		}
		if (Input.GetButtonUp ("Fire2")) {
			isFire = false;
		}
		if (isFire) {
			Destroy(Instantiate (Bullet, this.transform.position, this.transform.rotation),2);
			Destroy(Instantiate (FireLight, this.transform.position, this.transform.rotation),1f);
		}
	}
}
