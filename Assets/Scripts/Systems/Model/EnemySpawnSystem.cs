using System;
using System.Collections.Generic;
using Leopotam.Ecs;
using TowerDefenceLeoEcs.AppData;
using TowerDefenceLeoEcs.Blueprints;
using TowerDefenceLeoEcs.Components;
using TowerDefenceLeoEcs.Components.Requests;
using TowerDefenceLeoEcs.Extensions;
using TowerDefenceLeoEcs.Extensions.Blueprints;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TowerDefenceLeoEcs.Systems.Model
{
    internal sealed class EnemySpawnSystem : IEcsRunSystem
    {
        private readonly SceneData _sceneData = null;
        private readonly GameContext _context = null;

        private readonly EcsWorld _world = null;

        readonly EcsFilter<CreateEnemiesRequest> _createEnemyRequestFilter = null;

        void IEcsRunSystem.Run()
        {
            foreach (var createEnemyIdx in _createEnemyRequestFilter)
            {
                CreateEnemyWave(_createEnemyRequestFilter.Get1(createEnemyIdx).waveCount);
            }
        }

        private void CreateEnemyWave(int count)
        {
            int offset = 1;
            for (; count > 0; --count)
            {
                if (!TryGetRandomEnemy(out var mobBlueprint))
                    return;

                CreateEnemy(mobBlueprint, _sceneData.Path.GetPosition(0) - new Vector3(offset++, 0, 0));
            }
        }

        private bool TryGetRandomEnemy(out EnemyBlueprint enemyBlueprint)
        {
            var mobBlueprints = _context.EnemyBlueprints;
            enemyBlueprint = mobBlueprints.Random();
            return enemyBlueprint != default;
        }

        private void CreateEnemy(EnemyBlueprint enemyBlueprint, in Vector2 position)
        {
            var entity = enemyBlueprint.CreateEntity(_world);
            entity.Get<MoveComponent>().Destination = position;
            entity.Get<CreateViewRequest>().StartPosition = position;
        }
    }
}