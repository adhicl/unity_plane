using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private Vector3 defRotation;

    [SerializeField]
    private Vector3 defSpeed;

    [SerializeField]
    private float killTime;

    private Transform cTrans;

    private bool isDead = false;
    private float timeDead = 0f;

    public ParticleSystem cSpark;
    public TrailRenderer cTrail;

    private Bullet1Factory factory;

	public void SetTrajectory(Vector3 rot, Vector3 spd)
	{
        defSpeed = spd;
        defRotation = rot;

        cTrans.eulerAngles = rot;
	}

    // Update is called once per frame
    void Update()
    {
        if (isDead)
		{
            timeDead += Time.deltaTime;
            if (timeDead >= killTime)
			{
                KillMe();
            }
		}
		else
        {
            if (cTrans != null) cTrans.position += defSpeed * Time.deltaTime;
        }
    }

    public void SetFactory(Bullet1Factory iFactory)
	{
        factory = iFactory;
	}

    private void OnBecameInvisible()
	{
        KillMe();
	}
	private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            cSpark.Play();
            isDead = true;
        }
    }

	public void Init()
	{
        isDead = false;
        timeDead = 0f;
        cTrans = this.GetComponent<Transform>();
    }

    private void KillMe()
	{
        cTrail.Clear();
        if (factory) factory.ReturnObject(this);
    }
}
