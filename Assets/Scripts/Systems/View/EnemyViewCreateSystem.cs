using Leopotam.Ecs;
using TowerDefenceLeoEcs.Components.WrappersMonoBehaviour;
using TowerDefenceLeoEcs.Extensions.Components;
using TowerDefenceLeoEcs.Extensions.Systems.ViewCreate;
using TowerDefenceLeoEcs.Services;
using TowerDefenceLeoEcs.Systems.Model.Data;
using UnityEngine;
using TowerDefenceLeoEcs.Components;
using System;

namespace TowerDefenceLeoEcs.Systems.View
{
    internal sealed class EnemyViewCreateSystem : ViewCreateSystem<IsEnemyComponent>
    {
        private readonly PoolsObject _poolsObject = null;

        protected override Transform CreateView(in EcsEntity entity, in Vector3 startPosition)
        {
            var poolObject = _poolsObject.Enemies.Get();
            var transform = poolObject.PoolTransform;
            transform.localPosition = startPosition;
            transform.gameObject.SetActive(true);

            var rigidbody2D = transform.GetComponent<Rigidbody2D>();
            entity.Get<ViewObjectComponent>().ViewObject = new ViewObjectUnity(transform, rigidbody2D, poolObject);

            var spriteRenderer = transform.GetComponent<SpriteRenderer>();
            entity.Get<WrapperUnityComponent<SpriteRenderer>>().Value = spriteRenderer;

            return transform;
        }
    }
}