using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public float defaultVerticalSpeed = 2;
	float verticalSpeed = 2;

	public float stunDuration = 1f;

	// Use this for initialization
	void Start () {
		verticalSpeed = defaultVerticalSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector2.down * verticalSpeed * Time.deltaTime);
	}

	void Stun() {
		StartCoroutine("GetStunned");
	}

	IEnumerator GetStunned() {
		verticalSpeed = 0;
		gameObject.ShakePosition(Vector2.right, stunDuration, 0);
		yield return new WaitForSeconds(stunDuration);
		verticalSpeed = defaultVerticalSpeed;
	}

	void Slow(float modifier) {
		verticalSpeed = defaultVerticalSpeed * modifier;
	}

	void GetSlashed() {
		Destroy(gameObject);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Player")) {
			other.SendMessageUpwards("GotHit", SendMessageOptions.DontRequireReceiver);
		}
	}
}
