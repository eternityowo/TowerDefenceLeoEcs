using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using TowerDefenceLeoEcs.AppData;
using TowerDefenceLeoEcs.Components;
using TowerDefenceLeoEcs.Components.Events;
using TowerDefenceLeoEcs.Components.WrappersMonoBehaviour;
using TowerDefenceLeoEcs.Extensions.Components;
using TowerDefenceLeoEcs.Extensions.UnityComponent;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefenceLeoEcs.Systems
{
    internal sealed class KeepInitSystem : IEcsInitSystem
    {
        private readonly SceneData _sceneData;
        private readonly GameConfiguration _config;

        private readonly EcsWorld _world;

        void IEcsInitSystem.Init()
        {
            var keepTransform = _sceneData.Keep;

            var keepEntity = _world.NewEntity();

            keepEntity.Get<IsKeepComponent>();

            keepEntity.Get<HealthBaseComponent>().Value = _config.keepHealth;
            keepEntity.Get<HealthCurrentComponent>().Value = _config.keepHealth;
            keepEntity.Get<IsHealthChangeEvent>();

            keepEntity.Get<WrapperUnityComponent<Text>>().Value = _sceneData.KeepHealthText;
            keepEntity.Get<WrapperUnityComponent<Sprite>>().Value = _sceneData.Keep.GetComponent<Sprite>();

            keepTransform.GetProvider().SetEntity(keepEntity);
        }
    }
}