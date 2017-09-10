using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public GameProperty gameProperty;
	public Player player;
	public GameObject canvas;
	private bool isPlayerEnabled = false;
	private bool isGameOver = false;
	private bool isGamePlaying;
	public GameObject mainCamera;
	public Fade fade;
	public enum GameState {
		opening,
		play,
		fail,
		clear,
		pause
	}
	private GameState gameState = GameState.opening;

	// Use this for initialization
	void Start () {
		isGamePlaying = true;
		StartCoroutine ("showOpening");
	}
	
	// Update is called once per frame
	void Update () {
		if (!isGameOver) {						
			if (player.GetComponent<Player> ().getIsLiving()) {
				isPlayerEnabled = true;
			}
			if (isPlayerEnabled == true && !player.GetComponent<Player> ().getIsLiving()) {
				gameOver ();
			}
		}
	}

	public void clear () {
		Debug.Log ("cleared!");
		gameState = GameState.clear;
		instantiateNewGameObject ("GameClearPanel", canvas);
	}
		
	public void gameOver () {
		isGameOver = true;
		gameState = GameState.fail;
		instantiateNewGameObject ("GameOverPanel", canvas);
	}

	public void gameStart() {
		gameState = GameState.play;
		mainCamera.GetComponent<MoveFromToByTime> ().StartTween = true;
		fade.startFadeIn ();
		Debug.Log ("started");
	}

	public void instantiateNewGameObject (string ObjectName, GameObject parent) {
		GameObject obj;
		obj = Instantiate (Resources.Load ("prefabs/" + ObjectName)) as GameObject;
		obj.transform.SetParent (parent.transform, false);
	}

	public GameState getGameState () {
		return gameState;
	}

	IEnumerator showOpening() {
		fade.setColoer (0f, 0f, 0f, 1f);
		yield return new WaitForSeconds (gameProperty.openingSec);
		gameStart ();
	}
}
