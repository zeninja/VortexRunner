using UnityEngine;
using System.Collections;

public class AbilityController : MonoBehaviour {

	[System.Serializable]
	public enum Ability { sword, stun, slow, invisiblity };
	public Ability[] abilities = new Ability[4];

	public Meter meter;

	public GameObject sword;
	public float swordActiveTime = .25f;

	public GameObject stunPrefab;
	public int numStunShots = 5;
	public float timeBetweenStunShots = .5f;
	public GameObject shooter;

	public GameObject slowPrefab;
	public float slowDuration = 1;

	public float invisibilityDuration = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Trigger(int abilityNum) {
		switch(abilities[abilityNum]) {
			case Ability.sword:
				StartCoroutine("Sword");
				break;
			case Ability.stun:
				StartCoroutine("Stun");
				break;
			case Ability.slow:
				StartCoroutine("Slow");
				break;
			case Ability.invisiblity:
				StartCoroutine("Invisibility");
				break;
		}
	}

	IEnumerator Sword() {
		sword.SetActive(true);
		yield return new WaitForSeconds(swordActiveTime);
		sword.SetActive(false);
	}

	IEnumerator Stun() {
//		for(int i = 0; i < numStunShots; i++) {
//			GameObject stun = Instantiate(stunPrefab) as GameObject;
//			yield return new WaitForSeconds(timeBetweenStunShots);
//		}

		GameObject stun = Instantiate(stunPrefab) as GameObject;
		stun.transform.position = shooter.transform.position;
		yield return 0;
	}

	IEnumerator Slow() {
		GameObject slow = Instantiate(slowPrefab) as GameObject;
		slow.transform.position = new Vector2(0, shooter.transform.position.y);
		yield return new WaitForSeconds(slowDuration);
		slow.SetActive(false);
	}

	IEnumerator Invisibility() {
		SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
		Collider2D[] colliders = GetComponentsInChildren<BoxCollider2D>();

		for (int i = 0; i < sprites.Length; i++) {
			sprites[i].color = new Color(sprites[i].color.r, sprites[i].color.g, sprites[i].color.b, .5f);
			colliders[i].enabled = false;
		}

//		GetComponens<SpriteRenderer>().color = new Color(1, 1, 1, .5f);
//		GetComponent<Collider2D>().enabled = false;

		yield return new WaitForSeconds(invisibilityDuration);

		for (int i = 0; i < sprites.Length; i++) {
			sprites[i].color = new Color(sprites[i].color.r, sprites[i].color.g, sprites[i].color.b, 1f);
			colliders[i].enabled = true;
		}

//		GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
//		GetComponent<Collider2D>().enabled = true;
	}
}
