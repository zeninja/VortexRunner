using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class GameManager : MonoBehaviour {

	static GameManager instance;
	bool gameOver = false;

	public GUIStyle gameOverStyle;

	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void OnGUI () {
		if (gameOver) {
			if (GUI.Button(new Rect(0, 0, Screen.width, Screen.height), "Restart", gameOverStyle)) {
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
				Time.timeScale = 1;
			}
		}
	}
	
	public static void HandleGameOver() {
		instance.gameOver = true;
		Time.timeScale = 0;
	}
}
