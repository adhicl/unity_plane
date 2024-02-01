using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MainSceneController : MonoBehaviour
{
    private Bullet.Pool poolBullet;
    private EnemyBulletTarget.Pool pool;

    [Inject]
    public void Construct(PlayerController _player, EnemyBulletTarget.Pool _pool, Bullet.Pool _poolBullet)
    {
        pool = _pool;
        poolBullet = _poolBullet;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Screen.SetResolution(800, 600, true);
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
}
