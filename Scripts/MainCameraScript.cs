using UnityEngine;
using System.Collections;

public class MainCameraScript : MonoBehaviour {

	public GameProperty gameProperty;
	public GameObject player;
	private Rigidbody rb;
	private float scrollSpeed;
	public GameManager gameManager;
	public Vector3 playStartPos;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		scrollSpeed = gameProperty.scrollSpeed;
	}
	
	// Update is called once per frame
	void Update () {
//		if (gameManager.getGameState() == GameManager.GameState.pl) {
//			if (GetComponent<MoveFromToByTime> ().StartTween == false) {
//				gameManager.gameStart ();
//			}
//		}
		if (gameManager.getGameState() == GameManager.GameState.play) {
			scroll ();
		} else {
			stopScroll ();
		}
	}

	void scroll () {
		Vector3 vec3 = rb.velocity;
		vec3.x = scrollSpeed;
		rb.velocity = vec3;
	}

	void stopScroll () {
		Vector3 vec3 = rb.velocity;
		vec3.x = 0;
		rb.velocity = vec3;
	}
}
