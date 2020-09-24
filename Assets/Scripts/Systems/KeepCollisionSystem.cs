using Leopotam.Ecs;
using TowerDefenceLeoEcs.Components;
using TowerDefenceLeoEcs.Components.Events.UnityEvents;
using TowerDefenceLeoEcs.Components.Requests;
using TowerDefenceLeoEcs.Extensions.Components;

namespace TowerDefenceLeoEcs.Systems
{
    internal sealed class KeepCollisionSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ContainerComponents<OnTriggerEnter2DEvent>, IsKeepComponent> _filter = null;

        void IEcsRunSystem.Run()
        {
            foreach (var i in _filter)
            {
                ref var keep = ref _filter.GetEntity(i);

                var collisions = _filter.Get1(i).List;

                foreach (var collision in collisions)
                {
                    var otherEntity = collision.Other;
                    ProcessEnemyCollision(keep, collision.Other);
                }
            }
        }

        private void ProcessEnemyCollision(in EcsEntity keep, in EcsEntity enemy)
        {
            if (!enemy.IsAlive()) return;

            var damage = enemy.Get<ContainerDamageComponent>().DamageRequest.Damage;

            enemy.Get<IsReachKeepComponent>();
            enemy.Get<IsDestroyEntityRequest>();

            keep.Get<MakeDamageRequest>().Damage += damage;
        }
    }
}