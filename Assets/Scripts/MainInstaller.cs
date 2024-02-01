using UnityEngine;
using Zenject;

public class MainInstaller : MonoInstaller
{
    [SerializeField]
    private MainSceneController mainSceneController;

    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private EnemyBulletTarget targetBulletPrefab;

    [SerializeField]
    private Bullet bulletPrefab;

    public override void InstallBindings()
    {
        Container.BindInstance(mainSceneController).AsSingle();
        Container.BindInstance(playerController).AsSingle();

        Container.BindMemoryPool<EnemyBulletTarget, EnemyBulletTarget.Pool>().FromComponentInNewPrefab(targetBulletPrefab);
        Container.BindMemoryPool<Bullet, Bullet.Pool>().FromComponentInNewPrefab(bulletPrefab);
        //Container.BindFactory<Object, EnemyBulletTarget, EnemyBulletTarget.Factory>().FromFactory<EnemyBulletFactory>();
    }
}