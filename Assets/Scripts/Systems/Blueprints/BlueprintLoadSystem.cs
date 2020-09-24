using System.Linq;
using Leopotam.Ecs;
using TowerDefenceLeoEcs.AppData;
using TowerDefenceLeoEcs.Blueprints;
using TowerDefenceLeoEcs.Extensions.Blueprints;
using UnityEngine;

namespace TowerDefenceLeoEcs.Systems.Blueprints
{
    internal sealed class BlueprintLoadSystem : IEcsInitSystem
    {
        private readonly GameConfiguration _config = null;
        private readonly GameContext _context = null;

        void IEcsInitSystem.Init()
        {
            var enemyBlueprints = Resources.LoadAll<EnemyBlueprint>(_config.enemyBlueprintsPath);
            _context.EnemyBlueprints = enemyBlueprints.ToList();

            var towerBlueprints = Resources.LoadAll<TowerBlueprint>(_config.towerBlueprintsPath);
            _context.TowerBlueprints = towerBlueprints.ToList();
        }
    }
}