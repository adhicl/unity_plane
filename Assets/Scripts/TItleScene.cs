using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class TItleScene : MonoBehaviour
{
	[SerializeField] private PlayableDirector playableDirector;
	[SerializeField] private GameObject titleScene;

	public void OnStart()
	{
		titleScene.SetActive(false);
		playableDirector.Play();
	}
}