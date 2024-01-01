using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "EnemyBehavior/EnemyClosingBehavior", order = 1)]

public class EnemyClosingBehavior : EnemyBehavior
{
	public override void OnMove(Transform ob)
	{
		if (PlayerController.Instance != null)
		{
			ob.position = Vector3.MoveTowards(ob.position, PlayerController.Instance.transform.position, speed * Time.deltaTime);
		}
	}
}
