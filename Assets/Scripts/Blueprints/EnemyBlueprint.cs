using System;
using Leopotam.Ecs;
using TowerDefenceLeoEcs.Extensions.Blueprints;
using TowerDefenceLeoEcs.Components;
using TowerDefenceLeoEcs.Components.Requests;
using UnityEngine;
using Unity.Mathematics;

namespace TowerDefenceLeoEcs.Blueprints
{
    [CreateAssetMenu(fileName = "Enemy", menuName = "TowerDefenceLeoEcs/Enemy", order = 100)]
    [Serializable]
    public class EnemyBlueprint : Blueprint
    {
        [SerializeField] internal HealthBaseComponent healthBaseComponent = new HealthBaseComponent() { Value = 1 };
        [SerializeField] internal MoveData moveSettings = new MoveData() { CanMove = true, MoveSpeed = 1 };
        [SerializeField] internal int damage = 1;

        public override EcsEntity CreateEntity(EcsWorld world)
        {
            var entity = world.NewEntity();
            entity.Get<IsEnemyComponent>();

            entity.Get<MoveComponent>() = new MoveComponent() { Data = moveSettings };
            entity.Get<MoveComponent>().StopSqrDistance = math.pow(entity.Get<MoveComponent>().Data.StopDistance, 2);
            entity.Get<MoveComponent>().NodeIndex = -1;
            entity.Get<MoveComponent>().Destination = Vector3.zero;
            entity.Get<MoveComponent>().LookInMoveDirection = true;

            entity.Get<HealthBaseComponent>() = healthBaseComponent;
            entity.Get<HealthCurrentComponent>().Value = healthBaseComponent.Value;
            entity.Get<ContainerDamageComponent>().DamageRequest = new MakeDamageRequest() { Damage = damage };

            entity.Get<GoldComponent>().Value = (healthBaseComponent.Value / 20) + damage * 5;

            return entity;
        }
    }
}