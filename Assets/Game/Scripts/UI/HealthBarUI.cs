using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI
{
    public sealed class HealthBarUI : MonoBehaviour
    {
        [SerializeField] private Image imageForeground;
    
        public void UpdateHealthImage(float value)
        {
            imageForeground.fillAmount = value;
        }
    }
}
