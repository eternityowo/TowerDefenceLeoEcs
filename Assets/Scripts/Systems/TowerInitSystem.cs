using Leopotam.Ecs;
using TowerDefenceLeoEcs.AppData;
using TowerDefenceLeoEcs.Components;
using TowerDefenceLeoEcs.Components.Timers;
using TowerDefenceLeoEcs.Extensions;
using TowerDefenceLeoEcs.Extensions.Components;
using TowerDefenceLeoEcs.Extensions.UnityComponent;
using UnityEngine;

namespace TowerDefenceLeoEcs.Systems
{
    internal sealed class TowerInitSystem : IEcsInitSystem
    {
        private readonly GameContext _context;

        private readonly EcsWorld _world;

        private const string towerTag = "Tower";

        void IEcsInitSystem.Init()
        {
            foreach (var towerObject in GameObject.FindGameObjectsWithTag(towerTag))
            {
                var entity = _context.TowerBlueprints.Random().CreateEntity(_world);
                entity.Get<TimerBetweenShotsComponent>().TimeLostSec = entity.Get<TimeBetweenShotsSetupComponent>().TimeSec;
                entity.Get<ContainerQueue<EcsEntity>>();

                towerObject.transform.GetProvider().SetEntity(entity);
            }
        }
    }
}
