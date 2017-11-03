using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScripts : MonoBehaviour {
	public float speed = 10f;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxisRaw ("Horizontal") * speed *Time.deltaTime;
		float v = Input.GetAxisRaw ("Vertical") * speed *Time.deltaTime;
		Vector3 CannonRotation = transform.eulerAngles;
		CannonRotation.z += v;
		CannonRotation.y += h;
		CannonRotation.z = Mathf.Clamp(CannonRotation.z, 0, 45);
		transform.rotation = Quaternion.Euler(CannonRotation);	
	}
}
