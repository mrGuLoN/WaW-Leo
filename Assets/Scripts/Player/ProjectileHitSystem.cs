using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProjectileHitSystem : IEcsRunSystem
{
    private EcsFilter<Projectile, ProjectileHit> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            ref var projectile = ref filter.Get1(i);
           
            Debug.Log(projectile.projectileGO);
            //PollObjects.Instance.DestroyGameObject(projectile.projectileGO);
            projectile.projectileGO.SetActive(false);
            Debug.Log("ProjectileHitSystem Worked");
            // Здесь немного пустовато. Мы добавим больше функционала в новых частях
        }
    }
}