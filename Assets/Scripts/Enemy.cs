using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float health;
    
    [SerializeField] private float baseHealth;
    [SerializeField] private float shootInterval;
    [SerializeField] private EnemyBehavior behavior;

    private bool isAlive = false;
    private bool isDead = false;

	private void Start()
	{
        Init();
	}

	private void Init()
	{
        health = baseHealth;
	}

    private float timerShoot = 0f;
	private void Update()
	{
        if (!isAlive) return;

        timerShoot += Time.deltaTime;
        if (timerShoot >= shootInterval)
		{
            timerShoot = 0f;
            ShootBullet();
		}
        //behavior.OnMove(this.transform);
	}

    protected virtual void ShootBullet()
	{
        EnemyBullet1Factory.Instance.CreateNewBullet(this.transform.position);
    }

	private void OnTriggerEnter(Collider other)
    {
        if (!isAlive) return;
        if (other.tag == "Bullet")
        {
            Debug.Log("hit bu bullet");
        }
    }

	private void OnBecameVisible()
	{
        if (!isAlive && !isDead)
        {
            isAlive = true;
            Debug.Log("turn on"+this.name);
        }
	}

	private void OnBecameInvisible()
	{
		if (isAlive)
		{            
            isAlive = false;
            isDead = true;
            Debug.Log("turn off" + this.name);
        }
	}
}
