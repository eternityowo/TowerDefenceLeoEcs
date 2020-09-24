using TowerDefenceLeoEcs.AppData;
using TowerDefenceLeoEcs.Extensions.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace TowerDefenceLeoEcs.Systems
{
    sealed class CameraSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly SceneData _sceneData;
        private readonly GameConfiguration _config;

        private readonly EcsWorld _world;

        private readonly EcsFilter<WrapperUnityComponent<Camera>> _cameraFilter = null;

        private float moveSpeed;
        private float screenBorderInPx;

        private bool mouseInputOn;
        private Vector3 startMousePosition;

        private Vector2 screenSize, screenCenter;
        private Rect borderedScreenRect, screenRect;

        void IEcsInitSystem.Init()
        {
            var cameraEntity = _world.NewEntity();
            ref var cameraComponent = ref cameraEntity.Get<WrapperUnityComponent<Camera>>();
            cameraComponent.Value = _sceneData.Camera;

            moveSpeed = _config.CameraSpeed;
            screenBorderInPx = _config.ScreenBorderInPx;

            var startPoint = new Vector2(0 + screenBorderInPx, 0 + screenBorderInPx);
            var size = new Vector2(Screen.width - screenBorderInPx * 2f, Screen.height - screenBorderInPx * 2f);
            screenSize = new Vector2(Screen.width, Screen.height);
            screenCenter = screenSize / 2f;

            borderedScreenRect = new Rect(startPoint, size);
            screenRect = new Rect(Vector2.zero, screenSize);
        }

        void IEcsRunSystem.Run()
        {
            var input = GetKeysFormattedInput() + GetMouseFormattedInput() + GetMouseBorderInput();

            foreach (var i in _cameraFilter)
            {
                var cameraTransform = _cameraFilter.Get1(i).Value.transform;

                cameraTransform.position += (Time.deltaTime * moveSpeed * input.normalized);
            }
        }

        Vector3 GetKeysFormattedInput() => new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        Vector3 GetMouseFormattedInput()
        {
            if (Input.GetMouseButtonDown(1))
            {
                startMousePosition = Input.mousePosition;
                mouseInputOn = true;
            }

            if (Input.GetMouseButtonUp(1))
                mouseInputOn = false;

            if (!mouseInputOn)
                return Vector3.zero;

            var realInput = GetOffsettedInput(Input.mousePosition, startMousePosition);

            return ScreenPosToCameraDirection(realInput);
        }

        Vector3 GetMouseBorderInput()
        {
            var mousePosition = Input.mousePosition;

            if (borderedScreenRect.Contains(mousePosition) || !screenRect.Contains(mousePosition))
                return Vector3.zero;

            var realInput = GetOffsettedInput(Input.mousePosition, screenCenter);

            return ScreenPosToCameraDirection(realInput);
        }

        Vector2 GetOffsettedInput(Vector2 input, Vector2 center) => (input - center) / screenSize;
        Vector3 ScreenPosToCameraDirection(Vector2 screenPos) => new Vector3(screenPos.x, screenPos.y, 0);
    }
}
