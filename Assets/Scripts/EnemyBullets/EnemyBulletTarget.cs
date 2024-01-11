using System.Collections;
using UnityEngine;

public class EnemyBulletTarget : EnemyBullet
{
	private Vector3 moveDirection;

	public override void Init()
	{
		base.Init();

		this.transform.LookAt(PlayerController.Instance.transform.position);
		moveDirection = this.transform.forward;
	}

	protected override void OnMove()
	{
		base.OnMove();
		cTrans.position += moveDirection * Time.deltaTime * behavior.speed;
		HitOutside();
	}

	protected override void KillMe()
	{
		base.KillMe();
		if (factory) factory.ReturnObject(this);
	}
}
