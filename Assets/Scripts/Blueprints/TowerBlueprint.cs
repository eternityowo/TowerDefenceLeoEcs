using System;
using Leopotam.Ecs;
using TowerDefenceLeoEcs.Extensions.Blueprints;
using UnityEngine;
using TowerDefenceLeoEcs.Components;
using TowerDefenceLeoEcs.Components.Requests;

namespace TowerDefenceLeoEcs.Blueprints
{
    [CreateAssetMenu(fileName = "Tower", menuName = "TowerDefenceLeoEcs/Tower", order = 200)]
    [Serializable]
    public class TowerBlueprint : Blueprint
    {
        [SerializeField] private Sprite sprite;
        [SerializeField] private int damage = 10;
        [SerializeField]
        private TimeBetweenShotsSetupComponent timeBetweenShotsSetupComponent 
            = new TimeBetweenShotsSetupComponent() { TimeSec = 0.15f };
        [SerializeField] private int cost = 10;

        public override EcsEntity CreateEntity(EcsWorld world)
        {
            var entity = world.NewEntity();
            entity.Get<TimeBetweenShotsSetupComponent>() = timeBetweenShotsSetupComponent;
            entity.Get<IsTowerComponent>();
            entity.Get<ContainerDamageComponent>().DamageRequest = new MakeDamageRequest() { Damage = damage };
            return entity;
        }
    }
}