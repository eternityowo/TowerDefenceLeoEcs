using Leopotam.Ecs;

namespace TowerDefenceLeoEcs.Extensions.UnityComponents
{
    public interface IEcsUnityProvider
    {
        ref EcsEntity Entity { get; }

        void SetEntity(in EcsEntity entity);
    }
}