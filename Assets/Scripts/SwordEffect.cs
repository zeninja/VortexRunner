﻿using UnityEngine;
using System.Collections;

public class SwordEffect : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Enemy")) {
			other.SendMessage("GetSlashed");
		}	
	}
}
