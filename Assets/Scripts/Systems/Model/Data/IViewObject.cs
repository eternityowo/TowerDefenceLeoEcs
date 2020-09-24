using UnityEngine;

namespace TowerDefenceLeoEcs.Systems.Model.Data
{
    public interface IViewObject
    {
        Vector2 Position { get; set; }
        Quaternion Rotation { get; set; }

        void MoveTo(in Vector2 vector2);
        void Destroy();
    }
}