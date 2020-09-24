using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using TowerDefenceLeoEcs.Components;
using TowerDefenceLeoEcs.Components.Events;
using TowerDefenceLeoEcs.Components.Requests;
using Unity.Mathematics;
using UnityEngine;

namespace TowerDefenceLeoEcs.Systems
{
    internal sealed class HealthTakeDamageSystem : IEcsRunSystem
    {
        private readonly EcsFilter<MakeDamageRequest, HealthCurrentComponent> _damageFilter = null;

        void IEcsRunSystem.Run()
        {
            foreach (var i in _damageFilter)
            {
                ref var makeDamageRequest = ref _damageFilter.Get1(i);
                ref var healthCurrent = ref _damageFilter.Get2(i);
                var healthCurrentValue = healthCurrent.Value - makeDamageRequest.Damage;
                healthCurrent.Value = math.clamp(healthCurrentValue, 0, int.MaxValue);

                ref var entity = ref _damageFilter.GetEntity(i);

                entity.Get<IsHealthChangeEvent>();

                if (healthCurrent.Value == 0)
                {
                    entity.Del<HealthCurrentComponent>();
                }
            }
        }
    }
}