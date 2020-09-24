using Leopotam.Ecs;
using TowerDefenceLeoEcs.Components;
using TowerDefenceLeoEcs.Components.Requests;

namespace TowerDefenceLeoEcs.Systems
{
    internal class GoldOnEnemyKillSystem : IEcsRunSystem
    {
        // private readonly EcsWorld _world = null;
        private readonly EcsFilter<GoldComponent, IsDestroyEntityRequest>.Exclude<IsReachKeepComponent> _killEnemyFilter = null;

        void IEcsRunSystem.Run()
        {
            foreach(var idx in _killEnemyFilter)
            {
                //ref var goldComponent = ref _killEnemyFilter.Get1(idx);

                //ref var goldEvent = ref _world.NewEntity().Get<ChangeGoldRequest>();
                //goldEvent.Value = goldComponent.Value;

                ////_world.NewEntity().Get<ChangeGoldRequest>().Value = goldComponent.Value;

                ref var goldComponent = ref _killEnemyFilter.GetEntity(idx);
                goldComponent.Get<ChangeGoldRequest>().Value = goldComponent.Get<GoldComponent>().Value;
            }
        }
    }
}
