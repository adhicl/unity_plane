using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "EnemyBehavior/EnemyStraightMoveBehavior", order = 2)]

public class EnemyMoveStraightBehavior : EnemyBehavior
{
	[Tooltip("direction only x and y, use 0 or 1, do not change z")]
	public Vector3 moveDirection;
	public override void OnMove(Transform ob)
	{
		ob.position += moveDirection * speed * Time.deltaTime;
	}
}
