using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectileSystem : IEcsRunSystem
{
    private EcsFilter<Weapon, SpawnProjectile> filter;
    private EcsWorld ecsWorld;

    public void Run()
    {
        foreach (var i in filter)
        {
            ref var weapon = ref filter.Get1(i);
            

            Debug.Log("Spawned Worked");
           

            for (int j = 0; j < weapon.pellet; j++)
            {
                float _randHor = Random.Range((-weapon.scater - 1) / 180, (weapon.scater + 1) / 180);
                float _randVer = Random.Range((-weapon.scater / 2 - 1) / 180, (weapon.scater / 2 + 1) / 180);

                var projectileGO = PollObjects.Instance.GetObject(weapon.bullet);
                projectileGO.transform.position = weapon.projectileSocket.position;
                projectileGO.transform.rotation = weapon.projectileSocket.rotation;
                var projectileEntity = ecsWorld.NewEntity();
                ref var projectile = ref projectileEntity.Get<Projectile>();               
                projectile.damage = weapon.weaponDamage;
                projectile.direction = weapon.projectileSocket.forward + new Vector3(_randHor, _randVer, 0);
                projectile.speed = weapon.projectileSpeed;                
                projectile.previousPos = projectileGO.transform.position;
                projectile.projectileGO = projectileGO;
                projectile.projectileGO.GetComponent<PoolIdentificate>().Destroyer(projectile.projectileGO);

                ref var entity = ref filter.GetEntity(i);
                entity.Del<SpawnProjectile>();
                Debug.Log(j);
            }                 
        }
    }
}
