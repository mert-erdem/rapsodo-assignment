using Game.Scripts.Managers;
using TMPro;
using UnityEngine;

namespace Game.Scripts.UI
{
    public sealed class PanelInGame : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textPoints;
        [SerializeField] private HealthBarUI healthBarUI;

        private void Start()
        {
            PointsManager.Instance.OnCurrentPointsChanged += SetTextPoints;
        }

        public void UpdateHealthBar(float healthPercentage)
        {
            healthBarUI.UpdateHealthImage(healthPercentage);
        }

        private void SetTextPoints(object sender, int currentPoints)
        {
            textPoints.text = "Points: " + currentPoints;
        }
    }
}
