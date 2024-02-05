using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

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
    private bool isRemove = false;
    private float timeDead = 0f;

    public ParticleSystem cSpark;
    public TrailRenderer cTrail;

    private MainSceneController main;

    [Inject]
    public void Construct(MainSceneController _main)
    {
        main = _main;
    }

    public void SetTrajectory(Vector3 rot, Vector3 spd)
	{
        defSpeed = spd;
        defRotation = rot;

        cTrans.eulerAngles = rot;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRemove)
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
            HitOutside();
        }
    }
    /*
    public void SetFactory(Bullet1Factory iFactory)
	{
        factory = iFactory;
	}
    //*/
    /*
    private void OnBecameInvisible()
	{
        KillMe();
    }
    //*/
    protected void HitOutside()
    {
        Vector3 cPos = cTrans.position;
        if (cPos.x < -30f || cPos.x > 30f || cPos.z < -20f || cPos.z > 20f)
        {
            KillMe();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            cSpark.Play();
            isRemove = true;
        }
    }

	public void Init()
	{
        isDead = false;
        isRemove = false;
        timeDead = 0f;
        cTrail.Clear();
        cTrans = this.GetComponent<Transform>();
        this.GetComponent<Collider>().enabled = true;
    }

    private void KillMe()
	{
        cTrail.Clear();
        if (!isDead)
		{
            this.GetComponent<Collider>().enabled = false;
            main.DespawnBullet(this);
            isDead = true;
        }
            
    }

    public class Pool : MemoryPool<Bullet>
    {
    }
}
