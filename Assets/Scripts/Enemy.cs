using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float health;
    
    [SerializeField] private float baseHealth;

    [SerializeField] private EnemyBehavior behavior; 

	private void Start()
	{
        Init();
	}

	private void Init()
	{
        health = baseHealth;
	}

	private void Update()
	{
        behavior.OnMove(this.transform);
	}

	private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            
        }
    }
}
