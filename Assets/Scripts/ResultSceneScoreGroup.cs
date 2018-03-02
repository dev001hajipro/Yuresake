using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultSceneScoreGroup : MonoBehaviour
{

	void Start ()
	{
		transform.Find ("HiscoreText").GetComponent<Text> ().text = "HISCORE " + Store.HiScore.ToString ("00000");
		transform.Find ("scoreText").GetComponent<Text> ().text = "SCORE " + Store.Score.ToString ("00000");
	}
}
