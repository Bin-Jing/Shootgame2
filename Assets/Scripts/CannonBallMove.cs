using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallMove : MonoBehaviour {
	public float speed = 10f;
	public float hitback = 10f;
	public GameObject Boom;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		this.transform.Translate(new Vector3 (-speed * Time.deltaTime, 0, 0));
	}
	void OnCollisionEnter (Collision other) {

		if (other.gameObject.tag == "Enemy") {
			StartCoroutine (CannonBallHit());
			other.gameObject.GetComponent<EnemyHealth> ().applyDamage (50);
			other.transform.position -= other.transform.forward*hitback;
		}

	}
	IEnumerator CannonBallHit(){
		Destroy(Instantiate (Boom, this.transform.position, this.transform.rotation),2);
		Destroy (this.gameObject);
		yield return new WaitForSeconds(0f);


	}
}
