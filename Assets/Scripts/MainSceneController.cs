using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class MainSceneController : MonoBehaviour
{
    private PlayerController player;
    private Bullet.Pool poolBullet;
    private EnemyBulletTarget.Pool pool;

    [SerializeField] private TextMeshProUGUI tScore;
    [SerializeField] private GameObject[] gLifes;
    private float curScore = 0;
    private float curLife = 3;

    [Inject]
    public void Construct(PlayerController _player, EnemyBulletTarget.Pool _pool, Bullet.Pool _poolBullet)
    {
        pool = _pool;
        poolBullet = _poolBullet;
        player = _player;
    }

    // Start is called before the first frame update
    void Start()
    {
        curLife = 3;
        curScore = 0;
    }

	private void Update()
	{
        CheckImmune();
    }

	public void SpawnBullet(Transform transform)
	{
        EnemyBulletTarget bullet = pool.Spawn();
        bullet.transform.position = transform.position;
        bullet.Init();
    }

    public void SpawnPlayerBullet(Vector3 transform)
    {
        Bullet newBullet = poolBullet.Spawn();
        newBullet.transform.position = transform;
        newBullet.Init();
        newBullet.SetTrajectory(Vector3.zero, Vector3.forward * 50f);
    }

    public void DespawnBullet(EnemyBulletTarget bullet)
    {
        pool.Despawn(bullet);
    }
    public void DespawnBullet(Bullet bullet)
    {
        poolBullet.Despawn(bullet);
    }

    public void GetHit()
	{
        if (isImmune) return;

        isImmune = true;
        immuneTimer = 0f;

        curLife--;
        updateUI();
        player.GetHit();
	}

    protected void updateUI()
	{
        for (int i = 0; i < 3; i++)
		{
            if (i < curLife)
            {
                gLifes[i].SetActive(true);
			}
			else
			{
                gLifes[i].SetActive(false);
			}
		}
        tScore.text = curScore.ToString();
    }

    private bool isImmune = false;
    private float immuneTimer = 0f;
    protected void CheckImmune()
	{
        if (isImmune)
		{
            immuneTimer += Time.deltaTime;
            if (immuneTimer >= 1f)
            {
                immuneTimer = 0f;
                isImmune = false;
            }
        }
	}

    public void AddPoint(float point)
	{
        curScore += point;
        updateUI();
	}
}
