using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Utility : MonoBehaviour
{
	public const int SCENE_TITLE = 0;
	public const int SCENE_MAIN = 1;
	public const int SCENE_RESULT = 2;

	public void LoadScene (int sceneBuildIndex)
	{
		SceneManager.LoadScene (sceneBuildIndex);
	}
}
