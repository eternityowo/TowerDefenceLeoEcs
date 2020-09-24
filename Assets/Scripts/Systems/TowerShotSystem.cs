using Leopotam.Ecs;
using TowerDefenceLeoEcs.Components;
using TowerDefenceLeoEcs.Components.Requests;
using TowerDefenceLeoEcs.Components.Timers;
using TowerDefenceLeoEcs.Extensions.Components;

namespace TowerDefenceLeoEcs.Systems
{
    internal sealed class TowerShotSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ContainerQueue<EcsEntity>, IsTowerComponent> _enemyQuequ = null;
        //private readonly EcsFilter<TimerBetweenShotsComponent, TimeBetweenShotsSetupComponent, IsTowerComponent> _shotTowerSystem = null;

        void IEcsRunSystem.Run()
        {
            foreach (var i in _enemyQuequ)
            {
                ref var tower = ref _enemyQuequ.GetEntity(i);

                ref var entities = ref _enemyQuequ.Get1(i);

                if (!tower.Has<TimerBetweenShotsComponent>())
                {
                    foreach (var enemy in entities.Queue)
                    {
                        if (!enemy.IsAlive()) continue;

                        enemy.Get<MakeDamageRequest>().Damage += tower.Get<ContainerDamageComponent>().DamageRequest.Damage;
                        tower.Get<TimerBetweenShotsComponent>().TimeLostSec = tower.Get<TimeBetweenShotsSetupComponent>().TimeSec;

                        return;
                    }
                }
            }
        }
    }
}
