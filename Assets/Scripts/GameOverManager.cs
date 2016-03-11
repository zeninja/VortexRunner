using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverManager : MonoBehaviour {

	public PrototypeController player;
	public GUIStyle gameOverStyle;

	public float buttonWidth = 100;
	public float buttonHeight = 50;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI() {
		if (player.gameOver) {
			if (GUI.Button(new Rect(new Vector2(Screen.width/2 - buttonWidth/2, Screen.height/2 - buttonHeight/2), new Vector3(buttonWidth, buttonHeight)), "Restart", gameOverStyle)) {
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
				Time.timeScale = 1;
			}
		}
	}
}
