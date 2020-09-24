using Leopotam.Ecs;
using TowerDefenceLeoEcs.Components;
using TowerDefenceLeoEcs.Components.Events.UnityEvents;
using TowerDefenceLeoEcs.Extensions.Components;

namespace TowerDefenceLeoEcs.Systems
{
    internal sealed class TowerCollisionSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ContainerComponents<OnTriggerEnter2DEvent>, IsTowerComponent> _enemyEnterFilter = null;
        private readonly EcsFilter<ContainerComponents<OnTriggerExit2DEvent>, IsTowerComponent> _enemyExitFilter = null;

        void IEcsRunSystem.Run()
        {
            foreach (var i in _enemyEnterFilter)
            {
                ref var tower = ref _enemyEnterFilter.GetEntity(i);

                var collisions = _enemyEnterFilter.Get1(i).List;

                foreach (var collision in collisions)
                {
                    var otherEntity = collision.Other;
                    tower.Get<ContainerQueue<EcsEntity>>().Queue.Enqueue(otherEntity);
                }
            }

            foreach (var i in _enemyExitFilter)
            {
                ref var tower = ref _enemyExitFilter.GetEntity(i);

                var collisions = _enemyExitFilter.Get1(i).List;

                foreach (var collision in collisions)
                {
                    //  TODO replace Quequ (freezy tower will be break this logic)
                    tower.Get<ContainerQueue<EcsEntity>>().Queue.Dequeue();
                }
            }
        }
    }
}
