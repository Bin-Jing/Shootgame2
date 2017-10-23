using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	void OnGUI(){
		if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height/2+10, 110, 30), "About this game")) {
			Application.LoadLevel (3);
		}
		if (GUI.Button (new Rect (Screen.width / 2 - 35, Screen.height-50, 60, 30), "Start")) {
			Application.LoadLevel (1);
		}
	}
}
