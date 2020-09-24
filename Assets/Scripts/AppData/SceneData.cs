using UnityEngine;
using UnityEngine.UI;

namespace TowerDefenceLeoEcs.AppData
{
    public class SceneData : MonoBehaviour
    {
        [Header("Camera")]
        public Camera Camera = default;

        [Header("UI Elements")]
        public Canvas Canvas = default;
        public RectTransform PauseScreen = default;

        public Text KeepHealthText = default;
        public Text GoldText = default;

        [Header("Scene object")]
        public Transform SpawnPoint = default;
        public LineRenderer Path = default;
        public Transform FinishPoint = default;
        public Transform Keep = default;
    }
}