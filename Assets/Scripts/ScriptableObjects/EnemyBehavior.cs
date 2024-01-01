using System.Collections;
using UnityEngine;
public class EnemyBehavior : ScriptableObject
{
	[Range(1f, 20f)]
	[Tooltip("movement speed")]
	public float speed = 1f;

	public virtual void OnMove(Transform ob)
	{

	}
}
