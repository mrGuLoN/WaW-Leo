using Leopotam.Ecs;
using UnityEngine;

public class PlayerAnimationSystem : IEcsRunSystem
{
    private EcsFilter<Player, PlayerInputData> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            ref var player = ref filter.Get1(i);
            ref var input = ref filter.Get2(i);

            Vector3 direction = new Vector3(input.moveInput.x, 0, input.moveInput.z);
           
            if (direction != Vector3.zero)
            {
                player.playerAnimator.SetFloat("Horizontal", direction.x);
                player.playerAnimator.SetFloat("Vertical", direction.z);
                player.playerAnimator.SetBool("Stay", false);               
            }
            else if (Input.GetAxis("Mouse X") != 0)
            {
                player.playerAnimator.SetBool("Stay", true);
                player.playerAnimator.SetFloat("MouseHorizontal", Input.GetAxis("Mouse X")*10);               
            }    
            else
            {
                player.playerAnimator.SetBool("Stay", false);
                player.playerAnimator.SetFloat("Horizontal",0);
                player.playerAnimator.SetFloat("Vertical", 0);
            }

            player.playerAnimator.SetBool("Shooting", input.shootInput);            
        }
    }
}
