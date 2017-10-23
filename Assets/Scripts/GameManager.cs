using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	int score = 0;
	// Use this for initialization
	void Start () {

		score = 0;
	}

	// Update is called once per frame
	void Update () {

	}
	void OnDisable(){
		PlayerPrefs.SetInt ("Score", score);
	}
	public void addScore(int n){
		score += n;

	}
	void OnGUI(){
		GUIStyle style = new GUIStyle ();
		style.fontSize = 30;
		style.normal.textColor = Color.white;

		GUI.Label (new Rect (0, 0, 200, 60), "Score : " + score, style);
	}
}
