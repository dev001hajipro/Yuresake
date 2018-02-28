using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class ScorePlayModeTest
{

	[Test]
	public void ScorePlayModeTestValue ()
	{
		// 初期化
		var obj = new GameObject ("ScoreObject", new [] {
			typeof(Score)
		});
		var script = obj.GetComponent<Score> ();
		Assert.NotNull (script);
		script.scoreText = obj.GetComponent<Text> (); // 何故Textを持つ?
		Debug.Log (obj.GetComponent<Text> ());
		script.scoreText.text = 0.ToString ("00000");
		Assert.AreEqual (0, script.Value);

		// 点数を足したときのテスト
		int expectedSum = script.Value + script.addValue;
		script.Value += script.addValue;
		Assert.AreEqual (expectedSum, script.Value);

	}

	/*
	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator ScorePlayModeTestWithEnumeratorPasses ()
	{
		// Use the Assert class to test conditions.
		// yield to skip a frame
		yield return null;
	}
	*/
}
