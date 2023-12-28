using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy/EnemyScriptableObject", order = 1)]
public class EnemyScriptableObject : ScriptableObject
{
	[Range(0f, 1f)]
	[Tooltip("enemy health")]
	[SerializeField] private float health;
}
