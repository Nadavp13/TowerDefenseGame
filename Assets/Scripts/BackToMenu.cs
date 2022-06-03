using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
	public SceneFader sceneFader;
	public void MainMenu()
	{
		sceneFader.FadeTo("MainMenu");
	}
}
