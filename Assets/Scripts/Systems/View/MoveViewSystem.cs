using Leopotam.Ecs;
using TowerDefenceLeoEcs.Components;
using TowerDefenceLeoEcs.Components.WrappersMonoBehaviour;
using TowerDefenceLeoEcs.Components.Events;
using UnityEngine;
using TowerDefenceLeoEcs.AppData;

namespace TowerDefenceLeoEcs.Systems.Model.Move
{
    internal sealed class MoveViewSystem : IEcsRunSystem, IEcsInitSystem
    {
        private readonly SceneData _sceneData;

        private readonly EcsFilter<MoveComponent, ViewObjectComponent> _moveFilter = null;

        int nodeCount;

        void IEcsInitSystem.Init()
        {
            nodeCount = _sceneData.Path.positionCount - 1;
        }

        void IEcsRunSystem.Run()
        {
            var deltaTime = Time.deltaTime;

            foreach (var i in _moveFilter)
            {
                ref var moveComponent = ref _moveFilter.Get1(i);
                ref var viewObjectComponent = ref _moveFilter.Get2(i);

                var rawDirectionVector = moveComponent.Destination - viewObjectComponent.ViewObject.Position;
                var direction = rawDirectionVector.normalized;
                var distance = rawDirectionVector.sqrMagnitude;

                if (distance <= moveComponent.StopSqrDistance)
                {
                    if (moveComponent.NodeIndex < nodeCount)
                    {
                        moveComponent.Destination = _sceneData.Path.GetPosition(++moveComponent.NodeIndex);
                    }
                    continue;
                }

                viewObjectComponent.ViewObject.Position += deltaTime * moveComponent.Data.MoveSpeed * direction;

                // for rotate view
                //Vector3 rotatedVectorToTarget = Quaternion.Euler(0, 0, 90) * direction;
                //if (moveComponent.LookInMoveDirection)
                //    viewObjectComponent.ViewObject.Rotation = 
                //        Quaternion.RotateTowards(viewObjectComponent.ViewObject.Rotation, 
                //        Quaternion.LookRotation(Vector3.forward, rotatedVectorToTarget), 
                //        moveComponent.Data.RotationSpeed * deltaTime);

                viewObjectComponent.ViewObject.MoveTo(moveComponent.Data.MoveSpeed * direction);
            }
        }
    }

}