using UnityEngine;
using System.Collections;

public class CharacterPickup : MonoBehaviour {

	public float moveSpeed = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
	}
}
