using System;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefenceLeoEcs.AppData
{
    [CreateAssetMenu(fileName = "GameConfiguration", menuName = "TowerDefenceLeoEcs/GameConfig", order = 0)]
    public class GameConfiguration : ScriptableObject
    {
        public string enemyBlueprintsPath = "Blueprints/Enemies/";
        public string towerBlueprintsPath = "Blueprints/Towers/";

        [Header("Context Start Settings")]
        public float timeBetweenWave = 10f;
        public int startGold = 200;
        public int keepHealth = 1000;

        [Header("Camera Settings")]
        public float CameraSpeed = 10f;
        public int ScreenBorderInPx = 40;

        // TODOD Replace on CustomPropertyDrawer and Dictionary
        [Header("Health and Probs Settings")]
        [Tooltip("Probs and Bonus must be the same length ")]
        public List<int> healthProbs = new List<int>() { 75, 25, 5, 1 };
        public List<int> healthBonus = new List<int>() { 25, 75, 150, 300 };

        // TODOD Replace on CustomPropertyDrawer
        [Header("Damage and Probs Settings")]
        [Tooltip("Probs and Bonus must be the same length ")]
        public List<int> damageProbs = new List<int>() { 90, 9, 1 };
        public List<int> damageBonus = new List<int>() { 0, 1, 2 };

        public int EnemyWaveBonus = 5;

        // TODOD Replace on CustomPropertyDrawer
        //[Header("Health and Probs Settings")]
        //public List<BonusProb> healthProbBonus = default;
        //[Header("Damage and Probs Settings")]
        //public List<BonusProb> damageProbBonus = default;
    }

    // TODOD Replace on CustomPropertyDrawers
    //[Serializable]
    //public class BonusProb
    //{
    //    public int Prob;
    //    public int Bonus;
    //}
}