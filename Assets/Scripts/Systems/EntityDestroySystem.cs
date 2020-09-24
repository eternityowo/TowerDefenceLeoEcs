using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using TowerDefenceLeoEcs.Components.Requests;
using TowerDefenceLeoEcs.Components.WrappersMonoBehaviour;
using UnityEngine;

namespace TowerDefenceLeoEcs.Systems
{
    internal sealed class EntityDestroySystem : IEcsRunSystem
    {
        private readonly EcsFilter<ViewObjectComponent, IsDestroyEntityRequest> _withViewFilter = null;
        private readonly EcsFilter<IsDestroyEntityRequest> _withoutViewFilter = null;

        void IEcsRunSystem.Run()
        {
            foreach (var i in _withViewFilter)
            {
                _withViewFilter.Get1(i).ViewObject.Destroy();
            }

            foreach (var i in _withoutViewFilter)
            {
                _withoutViewFilter.GetEntity(i).Destroy();
            }
        }
    }
}
