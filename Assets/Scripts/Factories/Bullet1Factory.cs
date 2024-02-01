using System.Collections;
using UnityEngine;

public class Bullet1Factory : GenericFactory<Bullet>
{

	PlayerController controller;

	private void Awake()
	{
		this.Init();
		PlayerController.OnShoot += CreateNewBullet;
	}

	private void CreateNewBullet(Vector3 startPosition)
	{
		Bullet newBullet = this.GetObject(startPosition);
		newBullet.Init();
		//newBullet.SetFactory(this);
		newBullet.SetTrajectory(Vector3.zero, Vector3.forward * 50f);
	}
}