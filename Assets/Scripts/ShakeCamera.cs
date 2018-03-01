using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShakeCamera : MonoBehaviour
{
	public void Shake ()
	{
		Camera.main.transform.DOShakePosition (0.5f);
	}
}
