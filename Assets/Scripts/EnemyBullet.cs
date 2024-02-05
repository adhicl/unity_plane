using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

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

    protected MainSceneController main;

    [Inject]
    public void Construct(MainSceneController _main)
    {
        main = _main;
    }

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
        if (cPos.x < -35f || cPos.x > 35f || cPos.z < -20f || cPos.z > 25f)
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
            main.GetHit();
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
