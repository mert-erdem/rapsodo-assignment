using Game.Scripts.Managers;
using TMPro;
using UnityEngine;

namespace Game.Scripts.UI
{
    public sealed class PanelGameOver : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textPoints;

        private void OnEnable()
        {
            textPoints.text = "points: " + PointsManager.Instance.GetCurrentPoints();
        }

        public void OnButtonRestartClick()
        {
            GameManager.RestartLevel();
        }
    }
}
