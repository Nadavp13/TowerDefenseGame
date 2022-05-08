using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

	

	public string levelToLoad = "LevelSelect";
	public Button shopButton;
	public SceneFader sceneFader;

	void Start()
	{
		shopButton.interactable = false;
	}

	public void Play()
	{
		sceneFader.FadeTo(levelToLoad);
	}

	public void Shop()
	{
		sceneFader.FadeTo("Shop");
	}

	public void Achievements()
	{
		sceneFader.FadeTo("Achievements");
	}

	public void Quit()
	{
		Debug.Log("Exiting game...");
		Application.Quit();
	}

}	