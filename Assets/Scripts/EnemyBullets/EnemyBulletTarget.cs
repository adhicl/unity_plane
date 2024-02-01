using System.Collections;
using Zenject;
using UnityEngine;

public class EnemyBulletTarget : EnemyBullet
{
	private Vector3 moveDirection;

	private PlayerController player;
	private MainSceneController main;
	
	[Inject]
	public void Construct(PlayerController _player, MainSceneController _main)
	{
		player = _player;
		main = _main;
	}

	public override void Init()
	{
		base.Init();

		this.transform.LookAt(player.transform.position);
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
		if (!isDead) main.DespawnBullet(this);
		base.KillMe();
	}

	public class Pool : MemoryPool<EnemyBulletTarget>
	{
	}
}
