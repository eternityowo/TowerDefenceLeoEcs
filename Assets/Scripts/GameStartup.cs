using Leopotam.Ecs;
using TowerDefenceLeoEcs.AppData;
using TowerDefenceLeoEcs.Components.Events;
using TowerDefenceLeoEcs.Components.Events.InputEvents;
using TowerDefenceLeoEcs.Components.Events.UnityEvents;
using TowerDefenceLeoEcs.Components.Requests;
using TowerDefenceLeoEcs.Extensions.Components;
using TowerDefenceLeoEcs.Extensions.Systems.ViewCreate;
using TowerDefenceLeoEcs.Services;
using TowerDefenceLeoEcs.Systems.Blueprints;
using TowerDefenceLeoEcs.Systems.Model;
using TowerDefenceLeoEcs.Systems.Model.Move;
using TowerDefenceLeoEcs.Systems.View;
using UnityEngine;
using TowerDefenceLeoEcs.Systems;
using TowerDefenceLeoEcs.Components;
using TowerDefenceLeoEcs.Systems.Controller;

namespace TowerDefenceLeoEcs
{
    internal sealed class GameStartup : MonoBehaviour
    {
        public GameConfiguration Configuration = null;

        private EcsWorld _world;
        private EcsSystems _systems;

        private void Start()
        {
            var context = new GameContext();

            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
#endif

            _systems
                .Add(new BlueprintLoadSystem())

                .Add(new InputSystem())
                .Add(new GameStateInputSystem())

                // Binding to view on Scene
                .Add(new CameraSystem())
                .Add(new GoldInitSystem())
                .Add(new KeepInitSystem())
                .Add(new TowerInitSystem())

                // Start game loop
                .Add(new GameStartSystem())

                .Add(new WaveSystem())
                .Add(new EnemySpawnSystem())
                .Add(new EnemyViewCreateSystem())

                .Add(new MoveViewSystem())

                .Add(new KeepCollisionSystem())
                .Add(new TowerCollisionSystem())
                .Add(new TowerShotSystem())
                .Add(new TimerTickSystem())

                .Add(new HealthTakeDamageSystem())

                .Add(new KeepViewUpdateSystem())

                .Add(new ZeroHealthDamageSystem())

                .Add(new GoldOnEnemyKillSystem())
                //.Add(new GoldOnTowerUpgradeSystem())
                .Add(new GoldViewUpdateSystem())

                .Add(new EntityDestroySystem())

                .Add(new GameStateChangeSystem())
                .Add(new GameOverSystem())

                // register one-frame components
                .OneFrame<InputAnyKeyEvent>()
                .OneFrame<InputPauseQuitEvent>()
                .OneFrame<InputRestartLeveltEvent>()
                .OneFrame<CreateEnemiesRequest>()
                .OneFrame<CreateViewRequest>()
                .OneFrame<IsViewCreatedEvent>()
                .OneFrame<IsHealthChangeEvent>()
                .OneFrame<ChangeGoldRequest>()
                .OneFrame<MakeDamageRequest>()
                .OneFrame<OnTriggerEnter2DEvent>()
                .OneFrame<OnTriggerExit2DEvent>()
                .OneFrame<ContainerComponents<OnTriggerEnter2DEvent>>()
                .OneFrame<ContainerComponents<OnTriggerExit2DEvent>>()


                // inject 
                .Inject(Configuration)
                .Inject(GetComponent<SceneData>())
                .Inject(context)
                .Inject(new PoolsObject())
                .Init();
        }

        private void Update()
        {
            _systems?.Run();
        }

        private void OnDestroy()
        {
            if (_systems != null)
            {
                _systems.Destroy();
                _systems = null;
                _world.Destroy();
                _world = null;
            }
        }
    }
}