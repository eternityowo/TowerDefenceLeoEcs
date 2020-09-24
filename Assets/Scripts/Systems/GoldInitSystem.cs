using Leopotam.Ecs;
using TowerDefenceLeoEcs.AppData;
using TowerDefenceLeoEcs.Components;
using TowerDefenceLeoEcs.Components.Requests;
using TowerDefenceLeoEcs.Extensions.Components;
using UnityEngine.UI;

namespace TowerDefenceLeoEcs.Systems
{
    internal class GoldInitSystem : IEcsInitSystem
    {
        private readonly SceneData _sceneData = null;
        private readonly GameConfiguration _config = null;

        private readonly EcsWorld _world = null;

        void IEcsInitSystem.Init()
        {
            var goldEntity = _world.NewEntity();
            goldEntity.Get<GoldComponent>();
            goldEntity.Get<WrapperUnityComponent<Text>>().Value = _sceneData.GoldText;
            goldEntity.Get<ChangeGoldRequest>().Value = _config.startGold;
        }
    }
}
