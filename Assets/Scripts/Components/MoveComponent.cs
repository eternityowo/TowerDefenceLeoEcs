using System;
using UnityEngine;

namespace TowerDefenceLeoEcs.Components
{
    public struct MoveComponent
    {
        public MoveData Data;
        public Vector2 Destination;
        public int NodeIndex;

        public float StopSqrDistance;
        public bool LookInMoveDirection;
    }

    [Serializable]
    public struct MoveData
    {
        public bool CanMove;
        public float MoveSpeed;
        public float RotationSpeed;
        public float StopDistance;
    }
}
