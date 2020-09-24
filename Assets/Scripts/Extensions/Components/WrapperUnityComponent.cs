using UnityEngine;

namespace TowerDefenceLeoEcs.Extensions.Components
{
    public struct WrapperUnityComponent<T>
        where T : Object
    {
        public T Value;
    }
}