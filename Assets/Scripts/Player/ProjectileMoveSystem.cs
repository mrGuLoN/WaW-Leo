using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProjectileMoveSystem : IEcsRunSystem
{
    private EcsFilter<Projectile> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            ref var projectile = ref filter.Get1(i);

            var position = projectile.projectileGO.transform.position;
            position += projectile.direction * projectile.speed * Time.deltaTime;
            projectile.projectileGO.transform.position = position;

            var displacementSinceLastFrame = position - projectile.previousPos;
            RaycastHit hit;
            Ray ray = new Ray(projectile.projectileGO.transform.position, projectile.projectileGO.transform.forward*0.01f);

            if (Physics.Raycast(ray, out hit, 0.01f))
            {
                ref var entity = ref filter.GetEntity(i);
                ref var projectileHit = ref entity.Get<ProjectileHit>();
                projectileHit.raycastHit = hit;
                PollObjects.Instance.DestroyGameObject(projectile.projectileGO);
            }

            //projectile.previousPos = projectile.projectileGO.transform.position;

            Debug.Log("ProjectileMoveSystem Worked");
        }
    }
}
