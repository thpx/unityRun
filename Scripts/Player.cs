using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Rigidbody rb;
	private LayerMask groundLayer;
	private RaycastHit hit;
	private bool isOnGround = true;
	private int jumpCnt;
	private bool isLiving = true;
	public GameProperty gameProperty;
	private float runSpeed;
	public float jumpSpeed;
	public int maxJumpCnt;
	public GameManager gameManager;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		runSpeed = gameProperty.scrollSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameManager.getGameState() == GameManager.GameState.play) {

			//接地判定
			checkOnGround ();

			//走る
			Vector3 vec3 = rb.velocity;
			vec3.x = runSpeed;
			rb.velocity = vec3;
		}
	}

	void checkOnGround() {
		var scale = transform.lossyScale.y * 0.5f;

		Physics.BoxCast (transform.position, new Vector3(1, 0, 1) * scale, transform.up * -1, out hit, transform.rotation);

		if (hit.distance <= scale) {
			if (isOnGround == false) {
				jumpCnt = 0;	
			}
			isOnGround = true;
		} else {
			isOnGround = false;
		}
	}

	void OnDrawGizmos() {
		var scale = transform.lossyScale.x * 0.5f;
		var isHit = Physics.BoxCast (transform.position, new Vector3(1, 0, 1) * scale, transform.up * -1, out hit, transform.rotation);
		if (isHit) {
			Gizmos.DrawRay (transform.position, transform.up * -1 * hit.distance);
			Gizmos.DrawWireCube (transform.position + transform.up * -1 * hit.distance, new Vector3(1, 0, 1) * scale * 2);
		} else {
			Gizmos.DrawRay (transform.position, transform.up * -1 * 100);
		}
	}

	public void jump () {
		if (canJump()) {
			Vector3 vec3 = rb.velocity;
			vec3.y = jumpSpeed;
			rb.velocity = vec3;
			jumpCnt++;
		}
	}

	public bool canJump () {
		return isOnGround || jumpCnt < maxJumpCnt;
	}

	void die () {
		isLiving = false;
		Vector3 vec3 = rb.velocity;
		vec3.x = 0;
		rb.velocity = vec3;
	}

	public bool getIsLiving() {
		return isLiving;
	}

//	void OnBecameInvisible() {
//		die ();
//	}

	void OnTriggerExit(Collider col) {
		if (col.gameObject.CompareTag("OutArea")) {
			die ();
		}
	}
}
