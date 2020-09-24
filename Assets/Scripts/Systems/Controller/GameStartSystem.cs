using Leopotam.Ecs;
using TowerDefenceLeoEcs.Components.Requests;
using TowerDefenceLeoEcs.Extensions;

namespace TowerDefenceLeoEcs.Systems.Controller
{
    internal class GameStartSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;

        void IEcsInitSystem.Init()
        {
            _world.SendMessage(new ChangeGameStateRequest() { State = GameStates.Pause });
        }
    }
}