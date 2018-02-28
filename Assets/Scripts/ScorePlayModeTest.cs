using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Analytics;
using DG.Tweening;

public class ScorePlayModeTest
{
	private GameObject obj;
	private Score script;

	[SetUp]
	public void Setup ()
	{
		// 初期化
		obj = new GameObject ("ScoreObject", new [] {
			typeof(Score)
		});
		script = obj.GetComponent<Score> ();
		Assert.NotNull (script);
		script.scoreText = obj.GetComponent<Text> (); // 何故Textを持つ?
		Debug.Log (obj.GetComponent<Text> ());
		script.scoreText.text = 0.ToString ("00000");
		Assert.AreEqual (0, script.Value);
	}


	[Test]
	public void ScorePlayModeTestValue ()
	{
		// 点数を足したときのテスト
		int expectedSum = script.Value + script.addValue;
		script.Value += script.addValue;
		Assert.AreEqual (expectedSum, script.Value);

		// 初期化
		script.Value = 0;
		Assert.AreEqual (0, script.Value);

	}

	// DoTweenのAPIを使っていても問題なく動作するか確認。
	[UnityTest]
	public IEnumerator CountupWithAnime ()
	{
		var tweener = script.UpWithAnime ();
		tweener.OnComplete (() => Assert.AreEqual (script.addValue, script.Value));

		yield return new WaitForSeconds (0.5f);

		Assert.AreEqual (script.addValue, script.Value);
	}
}
