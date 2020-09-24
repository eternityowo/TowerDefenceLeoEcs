using System.Collections.Generic;
using TowerDefenceLeoEcs.Blueprints;
using TowerDefenceLeoEcs.Components.Requests;
using UnityEngine;

namespace TowerDefenceLeoEcs.AppData
{
    internal class GameContext
    {
        public GameStates GameState = default;

        public List<EnemyBlueprint> EnemyBlueprints = default;
        public List<TowerBlueprint> TowerBlueprints = default;
    }
}