using UnityEngine;
using System.Collections;

public class MeterSection : MonoBehaviour {

	public int cost = 25;
	int index;
	Meter meter;

	bool ready;
	bool available;

	public bool canBeTapped;

	// Use this for initialization
	void Start () {
		meter = transform.parent.GetComponent<Meter>();
		index = cost/25 - 1;

		PrototypeGameManager prototypeGameManager = GameObject.FindObjectOfType<PrototypeGameManager>();
		canBeTapped = prototypeGameManager.meterSectionsCanBeTapped;
	}
	
	// Update is called once per frame
	void Update () {
		UpdateState();
	}

	void UpdateState() {
		available = meter.activeSections >= index + 1;
		GetComponent<SpriteRenderer>().enabled = available;

		ready = meter.meterAmount >= cost;
		SetReady();
	}

	void OnMouseDown() {
		if (ready) {
			if(canBeTapped) {			/// PROTOTYPE ONLY
				meter.Trigger(index);
			}
		}
	}

	void SetReady() {
		if(ready) {
			GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
		} else {
			GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .25f);
		}
	}
}
