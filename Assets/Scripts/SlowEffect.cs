using UnityEngine;
using System.Collections;

public class SlowEffect : MonoBehaviour {

	public float slowAmount = .75f;
	public float moveSpeed = 10;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Enemy")) {
			other.SendMessage("Slow", slowAmount);
		}
	}
}
