using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerShootSystem : IEcsRunSystem
{
    private EcsFilter<Player, PlayerInputData> filter;
    public void Run()
    {       

        foreach (var i in filter)
        {
            ref var shoot = ref filter.Get2(i);
            if (shoot.shootInput)
            {

            }
        }
    }
}
