﻿using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShootSystem : IEcsRunSystem
{
    private EcsFilter<Weapon, Shoot> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            ref var weapon = ref filter.Get1(i);

            ref var entity = ref filter.GetEntity(i);
            entity.Del<Shoot>();

            if (weapon.currentInMagazine > 0)
            {
                weapon.currentInMagazine--;
                
                ref var spawnProjectile = ref entity.Get<SpawnProjectile>();
                Debug.Log(spawnProjectile);
            }

            else // если патронов нет, начать перезарядку
            {
                ref var reload = ref entity.Get<TryReload>();
            }
        }
    }
}
