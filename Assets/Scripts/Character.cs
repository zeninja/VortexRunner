using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	Meter meter;

	bool selected;
	public int abilityIndex;

	public Color[] colors;

	public bool canTriggerByDragging = false;

	// Use this for initialization
	void Start () {
		meter = GameObject.FindObjectOfType<Meter>();



	}
	
	// Update is called once per frame
	void Update () {
		// THIS SHOULD BE TEMPORARY, ONLY BEING USED TO SET UP THE PROTOTYPE EASILY
		PrototypeGameManager prototypeGameManager = GameObject.FindObjectOfType<PrototypeGameManager>();
		canTriggerByDragging = prototypeGameManager.canTriggerByDraggingCharacters;
	}

	public void UpdateInfo(int index) {
		abilityIndex = index;

		//sprite = whatever
		GetComponent<SpriteRenderer>().color = colors[abilityIndex];
	}

	void OnFingerDown(FingerDownEvent e) {
		if (e.Selection == gameObject) {
			selected = true;
		}
	}

	void OnSwipe(SwipeGesture s) {
		if (s.Direction == FingerGestures.SwipeDirection.Up && selected) {
			if (canTriggerByDragging) {
				meter.Trigger(abilityIndex);
			}
		}
	}

	void OnFingerUp(FingerUpEvent e) {
		if (e.Selection == gameObject) {
			selected = false;
		}
	}
}
