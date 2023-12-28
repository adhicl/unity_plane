using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Bullet", menuName = "Bullet/BulletScriptableObject", order = 1)]
public class BulletScriptableObject : ScriptableObject
{
	[Tooltip("default rotation for bullet")]
	[SerializeField] private Vector3 defRotation;

	[Tooltip("default speed for bullet")]
	[SerializeField] private Vector3 defSpeed;

	[Range(.5f, 1f)]
	[Tooltip("time to remove object when after die")]
	[SerializeField] private float killTime;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
}
