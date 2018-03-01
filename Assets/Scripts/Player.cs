using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	private Rigidbody2D rb2d;
	private Vector2 movement = Vector2.zero;
	public float speed = 5f;

	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void Update ()
	{
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");
		movement = new Vector2 (horizontal, vertical);
	}

	void FixedUpdate ()
	{
		rb2d.AddForce (movement * speed);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name.Equals ("Bottom")) {
			Debug.Log ("Destroy player.");
		}
		if (other.CompareTag ("ObstacleScoreTriggerArea")) {
			Debug.Log ("Score! Obstacle.");
			GameObject.Find ("ScoreText").GetComponent<Score> ().UpWithAnime ();
		}
	}
}
