using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class ScrollObject : MonoBehaviour
{

	private Rigidbody2D rb2d;
	public Vector2 velocity = Vector2.zero;
	public bool autoStart = false;

	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		if (autoStart)
			rb2d.velocity = velocity;
	}

	public void Freeze ()
	{
		rb2d.velocity = Vector2.zero;
	}

	public void Thaw ()
	{
		rb2d.velocity = velocity;
	}
}
