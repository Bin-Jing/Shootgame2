using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour {

	public float speed = 10f;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		this.transform.Translate(new Vector3 (0, speed * Time.deltaTime, 0));
	}
	void OnCollisionEnter (Collision other) {
		
		if (other.gameObject.tag == "Enemy") {
			StartCoroutine (BulletHit());
			other.gameObject.GetComponent<EnemyHealth> ().applyDamage (10,1);
		}

	}
	IEnumerator BulletHit(){
		Destroy (this.gameObject);
		yield return new WaitForSeconds(0f);


	}
}
