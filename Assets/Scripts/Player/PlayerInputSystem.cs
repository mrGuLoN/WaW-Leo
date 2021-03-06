using Leopotam.Ecs;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerInputSystem : IEcsRunSystem
{
    private EcsFilter<PlayerInputData, HasWeapon> filter; // фильтр, который выдаст нам все сущности, у которых есть компонент PlayerInputData
    private Vector3 vector3;

    public void Run()
    {
        foreach (var i in filter)
        {
            
            ref var input = ref filter.Get1(i);
            ref var hasWeapon = ref filter.Get2(i);


            input.moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            input.shootInput = Input.GetMouseButton(0);

            if (Input.GetKeyDown(KeyCode.R))
            {
                ref var weapon = ref hasWeapon.weapon.Get<Weapon>();

                if (weapon.currentInMagazine < weapon.maxInMagazine) 
                {
                    ref var entity = ref filter.GetEntity(i);
                    entity.Get<TryReload>();
                }
            }

           
        }
    }
}
