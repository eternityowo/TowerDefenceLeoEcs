using Leopotam.Ecs;
using TowerDefenceLeoEcs.Components.WrappersMonoBehaviour;
using TowerDefenceLeoEcs.Components.Requests;
using TowerDefenceLeoEcs.Extensions.UnityComponent;
using UnityEngine;

namespace TowerDefenceLeoEcs.Extensions.Systems.ViewCreate
{
    internal abstract class ViewCreateSystem<TComponentFlag> : IEcsRunSystem
        where TComponentFlag : struct
    {
        protected readonly EcsWorld _world = null;
        protected EcsFilter<CreateViewRequest, TComponentFlag>.Exclude<ViewObjectComponent> _filter = null;

        void IEcsRunSystem.Run()
        {
            foreach (var i in _filter)
            {
                ref var entity = ref _filter.GetEntity(i);
                var startPosition = _filter.Get1(i).StartPosition;

                entity.Get<IsViewCreatedEvent>();
                
                var transform = CreateView(entity, startPosition);
                var provider = transform.GetProvider();
                provider.SetEntity(entity);
            }
        }

        protected abstract Transform CreateView(in EcsEntity entity, in Vector3 startPosition);
    }
}