using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemBehaviour : MonoBehaviour
{
	public enum ItemType
	{
		SpeedUp,
		SpeedDown,
	}

	public ItemType itemType;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			DOTween.Sequence ()
				.Join (gameObject.GetComponent<Transform> ().DOScale (Vector3.one * 3f, 0.5f))
				.Join (gameObject.GetComponent<SpriteRenderer> ().DOFade (0.0f, 0.5f))
				.OnComplete (() => Destroy (this.gameObject, 0.5f))
				.Play ();

			if (itemType.Equals (ItemType.SpeedUp)) {
				// TODO:プールおスポーン速度を変更、オブスタクルの速度変更。
			} else if (itemType.Equals (ItemType.SpeedDown)) {
				
			}
		}
	}
}
