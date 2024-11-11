using Game.Scripts.Managers;
using TMPro;
using UnityEngine;

namespace Game.Scripts.UI
{
    public sealed class PanelLevelPassed : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textPoints;

        private void OnEnable()
        {
            textPoints.text = "points: " + PointsManager.Instance.GetCurrentPoints();
        }

        public void OnButtonContinueClick()
        {
            GameManager.RestartLevel();
        }
    }
}
