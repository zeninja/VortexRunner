using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	public enum CharacterType { red, green, blue, yellow }
	
	public Color[] colors;
	
	public GameObject[] characters;
	
	GameObject from;

	// Use this for initialization
	void Start () {
		SetupCharacters();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void SetupCharacters() {
		for(int i = 0; i < characters.Length; i++) {
			characters[i].GetComponent<PlayerController>().playerManager = this;
			characters[i].GetComponent<PlayerController>().myType = (CharacterType) i;
		}
	}	
	
	void OnTap(TapGesture gesture) {		
		HandleSelection(gesture.Selection);
	}
	
	void OnSwipe(SwipeGesture gesture) {
		switch(gesture.Direction) {
			case FingerGestures.SwipeDirection.Up:
				Select(CharacterType.red);
				break;
			case FingerGestures.SwipeDirection.Down:
				Select(CharacterType.green);
				break;
			case FingerGestures.SwipeDirection.Left:
				Select(CharacterType.blue);
				break;
			case FingerGestures.SwipeDirection.Right:
				Select(CharacterType.yellow);
				break;
		}
	}
	
	void Select(CharacterType newType) {
		characters[0].GetComponent<PlayerController>().myType = newType;
		characters[0].GetComponent<PlayerController>().Transition();
	}
	
	public void HandleSelection(GameObject target) {
		if (target == null) {
			return;
		}
			
		if(from == null) {
			from = target;
		} else {
			Vector3 fromPos = from.transform.position;
			Vector3 toPos = target.transform.position;
			
			from.transform.position = toPos;
			target.transform.position = fromPos;
			
			from = null;
		}
	}
}
