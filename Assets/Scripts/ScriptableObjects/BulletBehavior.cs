using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Bullet", menuName = "BulletBehavior/BulletBehavior", order = 1)]

public class BulletBehavior : ScriptableObject
{
	[Range(1f, 20f)]
	[Tooltip("movement speed")]
	public float speed = 1f;
}
