using Leopotam.Ecs;
using TowerDefenceLeoEcs.Components.Timers;
using UnityEngine;

namespace TowerDefenceLeoEcs.Systems.Model
{
    internal sealed class TimerTickSystem : IEcsRunSystem
    {
        private readonly EcsFilter<TimerBetweenShotsComponent> _filterTimerBetweenShots = null;

        void IEcsRunSystem.Run()
        {
            MadeTickTimerBetweenShotsComponent();
        }

        private void MadeTickTimerBetweenShotsComponent()
        {
            foreach (var i in _filterTimerBetweenShots)
            {
                ref var timer = ref _filterTimerBetweenShots.Get1(i);
                timer.TimeLostSec -= Time.deltaTime;

                if (timer.TimeLostSec <= 0)
                {
                    _filterTimerBetweenShots.GetEntity(i).Del<TimerBetweenShotsComponent>();
                }
            }
        }
    }
}