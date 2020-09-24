using Leopotam.Ecs;
using TowerDefenceLeoEcs.Components;
using TowerDefenceLeoEcs.Components.Requests;
using TowerDefenceLeoEcs.Extensions.Components;
using UnityEngine.UI;

namespace TowerDefenceLeoEcs.Systems
{
    internal class GoldViewUpdateSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ChangeGoldRequest> _goldChangeFilter = null;
        private readonly EcsFilter<GoldComponent, WrapperUnityComponent<Text>> _goldViewFilter = null;

        public void Run()
        {
            foreach (var goldChangeIdx in _goldChangeFilter)
            {
                ref var value = ref _goldChangeFilter.Get1(goldChangeIdx).Value;

                foreach(var goldViewIdx in _goldViewFilter)
                {
                    ref var goldStorage = ref _goldViewFilter.Get1(goldViewIdx);
                    ref var goldView = ref _goldViewFilter.Get2(goldViewIdx);

                    goldStorage.Value += value;
                    goldView.Value.text = FormatText(goldStorage.Value);
                }
            }
        }

        string FormatText(int v)
        {
            return $"Gold: {v}";
        }
    }
}
