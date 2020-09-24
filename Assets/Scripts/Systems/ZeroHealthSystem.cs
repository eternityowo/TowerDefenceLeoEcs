using Leopotam.Ecs;
using TowerDefenceLeoEcs.Components;
using TowerDefenceLeoEcs.Components.Requests;
using UnityEngine;


namespace TowerDefenceLeoEcs.Systems
{
    internal sealed class ZeroHealthDamageSystem : IEcsRunSystem
    {
        private readonly EcsFilter<HealthBaseComponent>.Exclude<HealthCurrentComponent> _enemyWithZeroHealth = null;

        void IEcsRunSystem.Run()
        {
            foreach (var idx in _enemyWithZeroHealth)
            {
                _enemyWithZeroHealth.GetEntity(idx).Get<IsDestroyEntityRequest>();
            }
        }
    }
}