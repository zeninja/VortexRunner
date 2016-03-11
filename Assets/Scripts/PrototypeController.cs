using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class PrototypeController : MonoBehaviour {

	public float moveSpeed = 10;
	public float xBounds = 2.4f;
	public bool useTilt;

	Vector2 startPos;

	public int numCharacters = 1;
	public GameObject characterPrefab;
	public List<GameObject> characters;
	public GameObject defaultCharacter;
	public float spaceBetweenCharacters = .75f;

	[System.NonSerialized]
	public bool gameOver = false;
	public bool invincible;

	// Use this for initialization
	void Start () {
		characters = new List<GameObject>();
		characters.Add(defaultCharacter);
	}
	
	// Update is called once per frame
	void Update () {
		HandleMovement();

		if (gameOver) {
			if(Input.GetKeyDown(KeyCode.R)) {
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
		}
	}

	#region Movement
	void HandleMovement() {
		transform.Translate(Vector2.right * moveSpeed * Input.GetAxisRaw("Horizontal") * Time.deltaTime);

		if(useTilt) {
			transform.Translate(Vector2.right * moveSpeed * Input.acceleration.x * Time.deltaTime);
		}

		if(Mathf.Abs(transform.position.x) > xBounds) {
			transform.position = new Vector2(xBounds * Mathf.Sign(transform.position.x), transform.position.y);
		}
	}

	void OnFingerDown(FingerDownEvent e) {
		startPos = Camera.main.ScreenToWorldPoint(e.Position);
	}

	void OnFingerMove(FingerMotionEvent e) {
		if(!useTilt) {
			transform.position = (Vector2)transform.position + new Vector2(Camera.main.ScreenToWorldPoint(e.Position).x - startPos.x, 0);
			startPos = Camera.main.ScreenToWorldPoint(e.Position);
		}
	}
	#endregion

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Player")) {
			StartCoroutine("AddPlayer", other.gameObject);
		}
	}

	IEnumerator AddPlayer(GameObject pickup) {
		Time.timeScale = 0;
		GameObject newCharacter = Instantiate(characterPrefab) as GameObject;
		newCharacter.transform.position = pickup.transform.position;
		Destroy(pickup);

		characters.Add(newCharacter);
		newCharacter.transform.parent = transform;
		newCharacter.GetComponent<Character>().UpdateInfo(numCharacters);

		for(int i = 0; i < characters.Count; i++) {
			float xSpacing =  i - (float)(characters.Count - 1)/2;

			iTween.MoveTo(characters[i], 
			iTween.Hash("position", new Vector3(spaceBetweenCharacters * xSpacing, 0, 0),
						"time", .75f, "ignoretimescale", true, "isLocal", true));
		}

		yield return WaitForRealSeconds(1);
		Time.timeScale = 1;
		numCharacters++;
	}

    public static IEnumerator WaitForRealSeconds(float time)
    {
        float start = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup < start + time)
        {
            yield return null;
        }
    }

	void GotHit() {
		HandleGameOver();
	}

	void HandleGameOver() {
		if(!invincible) {
			gameOver = true;
			Time.timeScale = 0;
		}
	}
}