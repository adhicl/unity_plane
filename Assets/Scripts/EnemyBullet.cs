using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBullet : MonoBehaviour, IEnemyBullet
{
    [SerializeField]
    private float killTime;
    public BulletBehavior behavior;
    public GameObject goBullet;
    public ParticleSystem cSpark;

    protected Transform cTrans;
    protected EnemyBullet1Factory factory;

    protected bool isDead = false;
    private float timeDead = 0f;

    private void Start()
    {
        cTrans = this.transform;
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
            OnMove();
        }
    }

    private void OnBecameInvisible()
    {
        //Debug.Log("invisible " + this.name);
        //KillMe();
    }

    protected void HitOutside()
    {
        Vector3 cPos = cTrans.position;
        if (cPos.x < -30f || cPos.x > 30f || cPos.z < -7f || cPos.z > 27f)
        {
            KillMe();
        }
    }

    public void SetFactory(EnemyBullet1Factory iFactory)
    {
        factory = iFactory;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            cSpark.Play();
            goBullet.SetActive(false);
            KillMe();
        }
    }

    public virtual void Init()
    {
        isDead = false;
        timeDead = 0f;
        goBullet.SetActive(true);
    }

    protected virtual void KillMe()
    {
        isDead = true;
    }

    protected virtual void OnMove()
	{

	}
}
