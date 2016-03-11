using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	public PlayerManager playerManager;

	public PlayerManager.CharacterType characterType;
	public float moveSpeed = 10;

	// Use this for initialization
	void Start () {
		Setup();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
	}
	
	void Setup() {
		characterType = (PlayerManager.CharacterType)Random.Range(0, 4);
		
		for (int i = 0; i < 4; i++) {
			if (characterType == (PlayerManager.CharacterType)i ) {
				GetComponent<SpriteRenderer>().color = playerManager.colors[i];
			}
		}
	}
}
