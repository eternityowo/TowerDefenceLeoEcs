﻿using Leopotam.Ecs;
using UnityEngine;

namespace TowerDefenceLeoEcs.Extensions.Blueprints
{
    //[CreateAssetMenu(fileName = "FILENAME", menuName = "MENUNAME", order = 0)]
    public abstract class Blueprint : ScriptableObject
    {
        public abstract EcsEntity CreateEntity(EcsWorld world);
    }
}