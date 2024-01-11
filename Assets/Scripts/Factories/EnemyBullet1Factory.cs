using System.Collections;
using UnityEngine;

public class EnemyBullet1Factory : GenericFactory<EnemyBulletTarget>
{
	public static EnemyBullet1Factory Instance { get; private set; }

	private void Awake()
	{
		// If there is an instance, and it's not me, delete myself.

		if (Instance != null && Instance != this)
		{
			Destroy(this);
		}
		else
		{
			Instance = this;
			this.Init();
		}
	}

	public void CreateNewBullet(Vector3 startPosition)
	{
		EnemyBulletTarget newBullet = this.GetObject(startPosition);
		newBullet.Init();
		newBullet.SetFactory(this);
	}
}