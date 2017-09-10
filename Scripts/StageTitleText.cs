using UnityEngine;
using System.Collections;

public class StageTitleText : MonoBehaviour {
	public GameManager gameManager;
	public GameProperty gameProperty;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (gameManager.getGameState() != GameManager.GameState.opening) {
			Destroy (gameObject);
		}
	
	}
}
