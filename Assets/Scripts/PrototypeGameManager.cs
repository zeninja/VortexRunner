using UnityEngine;
using System.Collections;

public class PrototypeGameManager : MonoBehaviour {

	public enum Prototype { prototype1, prototype2, prototype3 }; 
	public Prototype prototype;

	PrototypeController controller;
	Meter meter;

	[System.NonSerialized]
	public bool canTriggerByDraggingCharacters;

	[System.NonSerialized]
	public bool meterSectionsCanBeTapped;

	// Use this for initialization
	void Start () {
		controller = GameObject.FindObjectOfType<PrototypeController>();
		meter = GameObject.FindObjectOfType<Meter>();

//		Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
		CheckPrototype();
	}

	void CheckPrototype() {
		switch(prototype) {
			case Prototype.prototype1:
				controller.useTilt = true;
				meter.useTapped = true;
				canTriggerByDraggingCharacters = false;
				meterSectionsCanBeTapped = true;
				break;
			case Prototype.prototype2:
				controller.useTilt = false;
				meter.useTapped = false;
				canTriggerByDraggingCharacters = false;
				meterSectionsCanBeTapped = true;
				break;
			case Prototype.prototype3:
				controller.useTilt = false;
				meter.useTapped = false;
				canTriggerByDraggingCharacters = true;
				meterSectionsCanBeTapped = false;
				break;
		}
	}
//
//	void SelectPrototype(Prototype type) {
//		prototype = type;
//	}
//
//	void StartGame() {
//		Time.timeScale = 1;
//		instructions.SetActive(false);
//	}
}
