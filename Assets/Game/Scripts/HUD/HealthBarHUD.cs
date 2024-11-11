using System;
using Game.Scripts.Player;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.HUD
{
    public class HealthBarHUD : MonoBehaviour
    {
        [SerializeField] private Image imageForeground, imageBackground;
        [SerializeField] private HealthSystem healthSystem;

        private void OnEnable()
        {
            imageForeground.enabled = true;
            imageBackground.enabled = true;
        }

        private void Start()
        {
            healthSystem.OnHealthDecrease += HealthSystem_OnHealthDecrease;
            healthSystem.OnDeath += HealthSystem_OnDeath;
            
            UpdateHealthImage(healthSystem.GetCurrentHealthPercentage());
        }

        private void LateUpdate()
        {
            transform.rotation = Quaternion.identity;
        }

        private void HealthSystem_OnHealthDecrease(object sender, float currentHealthPercentage)
        {
            UpdateHealthImage(currentHealthPercentage);
        }
    
        private void HealthSystem_OnDeath(object sender, EventArgs e)
        {
            imageForeground.enabled = false;
            imageBackground.enabled = false;
        }

        private void UpdateHealthImage(float value)
        {
            imageForeground.fillAmount = value;
        }

        private void OnDestroy()
        {
            healthSystem.OnHealthDecrease -= HealthSystem_OnHealthDecrease;
            healthSystem.OnDeath -= HealthSystem_OnDeath;
        }
    }
}