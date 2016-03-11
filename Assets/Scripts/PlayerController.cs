using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public PlayerManager.CharacterType myType;
	
	[System.NonSerialized] 
	public PlayerManager playerManager;
	
	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other) {		
		if (other.CompareTag("Obstacle")) {
			if (other.GetComponent<Obstacle>().characterType == myType) {
				HandleCorrectHit(other.gameObject);
			} else {
				HandleGameOver();
			}
		}
	}
	
	public void Transition() {
		for (int i = 0; i < 4; i++) {
			if (myType == (PlayerManager.CharacterType)i) {
				GetComponent<SpriteRenderer>().color = playerManager.colors[i];
			}
		}
	}
	
	void HandleCorrectHit(GameObject gameObject) {
		Destroy(gameObject);
		//increase score
	}
	
	void HandleGameOver() {		
		GameManager.HandleGameOver();
	}
}
