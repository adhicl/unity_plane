using System.Collections;
using UnityEngine;

public class EnemyMovementStraight : MonoBehaviour
{
	[SerializeField] private float speed;
	[SerializeField] private Vector3 moveDirection;

	private Enemy mEnemy;
	private Transform ob;

	// Use this for initialization
	void Start()
	{
		mEnemy = this.GetComponent<Enemy>();
		ob = this.transform;
	}

	// Update is called once per frame
	void Update()
	{
		if (mEnemy != null)
		{
			if (mEnemy.IsAlive())
			{
				ob.position += moveDirection * speed * Time.deltaTime;
			}
		}
	}
}