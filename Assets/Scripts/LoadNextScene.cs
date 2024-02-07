using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
	public string newScene;

	private void OnEnable()
	{
		SceneManager.LoadScene(newScene, LoadSceneMode.Single);
	}
}