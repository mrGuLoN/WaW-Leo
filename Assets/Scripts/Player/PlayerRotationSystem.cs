using Leopotam.Ecs;
using UnityEngine;

public class PlayerRotationSystem : IEcsRunSystem
{
    private EcsFilter<Player> filter;
    private SceneData sceneData;

    public void Run()
    {
        foreach (var i in filter)
        {
            ref var player = ref filter.Get1(i);          

            player.playerTransform.Rotate(0,Input.GetAxis("Mouse X")*player.playerSpeedRotation, 0);
            
        }
    }
}