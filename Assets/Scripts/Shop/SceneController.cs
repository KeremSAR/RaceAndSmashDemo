﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController: MonoBehaviour
{
	static int mainScene = 0;

	public static void LoadMainScene ()
	{
		SceneManager.LoadScene (mainScene);
	}

	public static void LoadNextScene ()
	{
		int currentScene = SceneManager.GetActiveScene ().buildIndex;
		PlayerPrefs.SetInt("SavedScene",currentScene);
		if (currentScene < SceneManager.sceneCountInBuildSettings)
			SceneManager.LoadScene (currentScene+1);
	}

	public static void LoadPreviousScene ()
	{
		int currentScene = SceneManager.GetActiveScene ().buildIndex;

		if (currentScene > 0)
			SceneManager.LoadScene (currentScene - 1);
	}

	public static void LoadScene (int index)
	{
		if (index >= 0 && index < SceneManager.sceneCountInBuildSettings)
			SceneManager.LoadScene (index);
	}

	public static void CurrentScene()
	{
		SceneManager.LoadScene(PlayerPrefs.GetInt("SavedScene")+1);
	}
}
