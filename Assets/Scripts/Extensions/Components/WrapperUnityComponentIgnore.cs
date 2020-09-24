using Leopotam.Ecs;
using UnityEngine;

namespace TowerDefenceLeoEcs.Extensions.Components
{
    public struct WrapperUnityComponentIgnore<T> : IEcsIgnoreInFilter
        where T : Object
    {
        public T Value;
    }
}