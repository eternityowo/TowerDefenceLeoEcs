using Leopotam.Ecs;
using System;
using System.Collections.Generic;
using TowerDefenceLeoEcs.AppData;
using TowerDefenceLeoEcs.Blueprints;
using TowerDefenceLeoEcs.Components;
using TowerDefenceLeoEcs.Components.Requests;
using TowerDefenceLeoEcs.Extensions;
using UnityEngine;

namespace TowerDefenceLeoEcs.Systems.Model
{
    internal sealed class WaveSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly GameConfiguration _config = null;
        private readonly GameContext _context = null;

        private readonly EcsWorld _world = null;

        private readonly EcsFilter<WaveComponent> _waveDataFilter = null;

        private float _timer;
        private float _timeUpdateSec;

        void IEcsInitSystem.Init()
        {
            _timeUpdateSec = _config.timeBetweenWave;
            _world.NewEntity().Get<WaveComponent>().CurrentWave = 1;
        }

        void IEcsRunSystem.Run()
        {
            if (_timer > 0)
            {
                _timer -= Time.deltaTime;
                return;
            }
            else
            {
                _timer = _timeUpdateSec;

                foreach (var enemyBlueprint in _context.EnemyBlueprints)
                {
                    var addHealth = _config.healthBonus[_config.healthProbs.RandomOnProbability()];
                    var addDamage = _config.damageBonus[_config.damageProbs.RandomOnProbability()];

                    enemyBlueprint.healthBaseComponent.Value += addHealth;
                    enemyBlueprint.damage += addDamage;
                }

                foreach (var i in _waveDataFilter)
                {
                    ref var waveContainer = ref _waveDataFilter.Get1(i);
                    waveContainer.CurrentWave += 1;
                    var enemiesInWaveCount = UnityEngine.Random.Range(waveContainer.CurrentWave, waveContainer.CurrentWave + _config.EnemyWaveBonus);
                    waveContainer.TotalEnemies += enemiesInWaveCount;
                    _world.SendMessage(new CreateEnemiesRequest() { waveCount = enemiesInWaveCount });
                }
            }
        }
    }
}