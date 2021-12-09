using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    sealed class EcsStartup : MonoBehaviour 
    {
        public StaticData configuration;
        public SceneData sceneData;

        private EcsWorld ecsWorld;
        private EcsSystems updateSystems;
        private EcsSystems fixedUpdateSystems; // новая группа систем

        private void Start()
        {
            ecsWorld = new EcsWorld();
            updateSystems = new EcsSystems(ecsWorld);
            fixedUpdateSystems = new EcsSystems(ecsWorld);
            RuntimeData runtimeData = new RuntimeData();

            updateSystems
            .Add(new PlayerInitSystem())
            .OneFrame<TryReload>()
            .Add(new PlayerInputSystem())
            .Add(new WeaponShootSystem())
            .Add(new SpawnProjectileSystem())
            .Add(new ProjectileMoveSystem())
            .Add(new ProjectileHitSystem())
            .Add(new ReloadingSystem())
            
            .Inject(configuration)
            .Inject(sceneData)           
            .Inject(runtimeData);

            fixedUpdateSystems
                .Add(new PlayerRotationSystem())               
                .Add(new PlayerMoveSystem())
                .Add(new PlayerAnimationSystem())

                .Inject(configuration)
                .Inject(sceneData)
                .Inject(runtimeData);

            // Инициализируем группы систем
            updateSystems.Init();
            fixedUpdateSystems.Init();
        }

        private void Update()
        {
            updateSystems?.Run();
        }

        private void FixedUpdate()
        {
            fixedUpdateSystems?.Run(); // запускаем их каждый тик FixedUpdate()
        }

        private void OnDestroy()
        {
            updateSystems?.Destroy();
            updateSystems = null;
            fixedUpdateSystems?.Destroy();
            fixedUpdateSystems = null;
            ecsWorld?.Destroy();
            ecsWorld = null;
        }
    }
}
