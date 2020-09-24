using Leopotam.Ecs;
using TowerDefenceLeoEcs.Components;
using TowerDefenceLeoEcs.Components.Events;
using TowerDefenceLeoEcs.Extensions.Components;
using UnityEngine.UI;

namespace TowerDefenceLeoEcs.Systems
{
    internal sealed class KeepViewUpdateSystem : IEcsRunSystem
    {
        private readonly EcsFilter<IsKeepComponent, IsHealthChangeEvent> _keepHealthChangeFilter = null;
        private readonly EcsFilter<IsKeepComponent, HealthCurrentComponent, WrapperUnityComponent<Text>> _keepViewFilter = null;

        public void Run()
        {
            if (!_keepHealthChangeFilter.IsEmpty())
            {
                foreach (var keepViewIdx in _keepViewFilter)
                {
                    ref var healthCurrent = ref _keepViewFilter.Get2(keepViewIdx);
                    ref var keepView = ref _keepViewFilter.Get3(keepViewIdx);

                    keepView.Value.text = FormatText(healthCurrent.Value);
                }
            }
        }

        string FormatText(int v)
        {
            return $"Keep health: {v}";
        }
    }
}