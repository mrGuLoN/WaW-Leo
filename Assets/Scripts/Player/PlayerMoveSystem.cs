using Leopotam.Ecs;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerMoveSystem : IEcsRunSystem
{
    private EcsFilter<Player, PlayerInputData> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            ref var player = ref filter.Get1(i);
            ref var input = ref filter.Get2(i);

            Vector3 direction = new Vector3(input.moveInput.x * player.playerSpeed, 0, input.moveInput.z * player.playerSpeed);
            direction = player.playerTransform.TransformVector(direction);            
            player.characterController.Move(direction * player.playerSpeed*Time.deltaTime);           
        }
    }
}
