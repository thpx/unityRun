using UnityEngine;
using System.Collections;

public class InputControler : MonoBehaviour {

	private GameObject Player;

	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("z") || Input.GetKeyDown("joystick button 1")) {
			Player.GetComponent<Player> ().jump ();
		}
	}
}
