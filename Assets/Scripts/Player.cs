using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements.StyleEnums;

public class Player : MonoBehaviour
{

	private Rigidbody2D rb2d;
	private Vector2 movement = Vector2.zero;
	public float speed = 5f;
	private Vector3 newPos = Vector3.zero;

	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		Store.Score = 0;
	}

	void Update ()
	{
		#if (UNITY_ANDROID || UNITY_IOS)
		/*
		transform.position = Vector3.MoveTowards (transform.position, newPos, Time.deltaTime * 100f);
		if (Input.touchCount > 0) {
			var touch = Input.touches [0];
			if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Ended) {
				newPos = Camera.main.ScreenToWorldPoint (touch.position);
				newPos.z = transform.position.z;
			}
		}
		*/
		if (Input.touchCount > 0) {
			var touch = Input.touches [0];
			//rb2d.velocity = new Vector2 ((touch.position.x - Screen.width / 2) * 1, rb2d.velocity.y);
			rb2d.velocity = new Vector2 ((Camera.main.ScreenToWorldPoint (touch.position).x - transform.position.x) * 3, rb2d.velocity.y);
			Debug.Log ((Camera.main.ScreenToWorldPoint (touch.position).x - transform.position.x) - transform.position.x);
		}
		#else
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");
		movement = new Vector2 (horizontal, vertical);
		#endif
	}

	void FixedUpdate ()
	{
		#if (UNITY_IOS || UNITY_ANDROID)
		#else
		rb2d.AddForce (movement * speed, ForceMode2D.Impulse);
		#endif
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name.Equals ("BottomDeadZone")) {
			this.gameObject.GetComponent<Utility> ().LoadScene (Utility.SCENE_RESULT);
		}
		if (other.CompareTag ("ObstacleScoreTriggerArea")) {
			GameObject.Find ("ScoreText").GetComponent<Score> ().UpWithAnime ();
		}
	}
}
