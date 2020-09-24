using Leopotam.Ecs;
using TowerDefenceLeoEcs.Extensions.Components;

namespace TowerDefenceLeoEcs.Extensions
{
    public static class EntityExtension
    {
        public static void AddEventToStack<T>(in this EcsEntity entity)
            where T : struct
        {
            var eventComponent = new T();
            AddEventToStack(entity, eventComponent);
        }

        public static void AddEventToStack<T>(in this EcsEntity entity, in T eventComponent)
            where T : struct
        {
            ref var containerComponents = ref entity.Get<ContainerComponents<T>>();
            containerComponents.List.Add(eventComponent);
        }
    }
}