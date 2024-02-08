using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Enemy : MonoBehaviour
{
    private float health;

    [SerializeField] private float point;
    [SerializeField] private float baseHealth;
    [SerializeField] private float shootInterval;

    [SerializeField] private Collider mCollider;
    [SerializeField] private GameObject mObject;
    [SerializeField] private ParticleSystem mExplosion;
    [SerializeField] private AudioSource aExplosion;

    private bool isAlive = false;
    private bool isDead = false;

    private PlayerController player;
    private MainSceneController mainSceneController;
    
    [Inject]
    public void Construct(PlayerController _player, MainSceneController _main)
    {
        player = _player;
        mainSceneController = _main;
    }

    private void Start()
	{
        Init();
	}

	private void Init()
	{
        health = baseHealth;
        isAlive = false;
        isDead = false;
        mObject.SetActive(true);
        mExplosion.time = 0;
        mCollider.enabled = true;
    }

    private float timerShoot = 0f;
	private void Update()
	{
        if (!isAlive) return;

        timerShoot += Time.deltaTime;
        if (timerShoot >= shootInterval && shootInterval > 0f)
		{
            timerShoot = 0f;
            ShootBullet();
		}

        //this.transform.LookAt(player.transform.position);
    }

    public bool IsAlive()
	{
        return isAlive;
	}

    protected virtual void ShootBullet()
	{   
        mainSceneController.SpawnBullet(this.transform);
    }

	private void OnTriggerEnter(Collider other)
    {
        if (!isAlive) return;

        if (other.tag == "Bullet")
        {
            health -= 1;
            if (health <= 0)
			{
                mExplosion.time = 0;
                mExplosion.Play(true);
                mObject.gameObject.SetActive(false);
                isAlive = false;
                isDead = true;
                mCollider.enabled = false;
                aExplosion.PlayOneShot(aExplosion.clip);
                mainSceneController.AddPoint(point);
			}
        }
    }

	private void OnBecameVisible()
	{
        if (!isAlive && !isDead)
        {
            isAlive = true;
        }
	}

	private void OnBecameInvisible()
	{
		if (isAlive)
		{            
            isAlive = false;
            isDead = true;
        }
	}
}
