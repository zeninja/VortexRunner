using UnityEngine;
using System.Collections;

public class Meter : MonoBehaviour {

	public PrototypeController player;
	public AbilityController abilityController;

	//[System.NonSerialized]
	public float meterAmount = 0;
	float maxAmount = 100;

	public float meterFillRate;
	public bool useTapped;

	public int activeSections;

	public bool debug;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		activeSections = player.numCharacters;
		maxAmount = activeSections * 25;

		if (debug) {
			maxAmount = 100;
			activeSections = 4;
		}

		UpdateMeter();
	}

	void UpdateMeter() {
		meterAmount += meterFillRate * Time.deltaTime;
		meterAmount = Mathf.Min(maxAmount, meterAmount);
	}

	public void Trigger(int abilityIndex) {
		if(useTapped) {
			// use only the meter section that was tapped
			if (meterAmount - (abilityIndex + 1) * 25 >= 0) {
				meterAmount -= (abilityIndex + 1) * 25;

				abilityController.Trigger(abilityIndex);
			}
		} else {
			// use as much of the meter as is available
			int maxAbilityIndex = Mathf.FloorToInt(meterAmount/25);

			if (maxAbilityIndex > 0) {
				meterAmount -= maxAbilityIndex * 25;
				maxAbilityIndex -= 1;

				abilityController.Trigger(maxAbilityIndex);
			}
		}
	}
}
