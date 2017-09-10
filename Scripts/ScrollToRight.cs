using UnityEngine;
using System.Collections;

public class ScrollToRight : MonoBehaviour {
	public GameProperty gameProperty;
	public GameManager gameManager;
	private Rigidbody rb;
	private float scrollSpeed;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		scrollSpeed = gameProperty.scrollSpeed;
	}
	
	// Update is called once per frame
	void Update () {
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
