using Leopotam.Ecs;
using TowerDefenceLeoEcs.Components.Requests;
using TowerDefenceLeoEcs.Components;
using TowerDefenceLeoEcs.Extensions;

namespace TowerDefenceLeoEcs.Systems.Controller
{
    internal sealed class GameOverSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<IsKeepComponent, HealthCurrentComponent> _filter = null;
        void IEcsRunSystem.Run()
        {
            if (_filter.IsEmpty())
            {
                _world.SendMessage(new ChangeGameStateRequest() { State = GameStates.GameOver });
            }
        }
    }
}