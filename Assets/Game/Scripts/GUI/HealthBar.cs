using System;
using Game.Scripts.Player;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.GUI
{
    public class HealthBar : MonoBehaviour
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
            
            UpdateHealthImage();
        }

        private void LateUpdate()
        {
            transform.rotation = Quaternion.identity;
        }

        private void HealthSystem_OnHealthDecrease(object sender, EventArgs e)
        {
            UpdateHealthImage();
        }
    
        private void HealthSystem_OnDeath(object sender, EventArgs e)
        {
            imageForeground.enabled = false;
            imageBackground.enabled = false;
        }

        private void UpdateHealthImage()
        {
            imageForeground.fillAmount = healthSystem.GetCurrentHealthPercentage();
        }

        private void OnDestroy()
        {
            healthSystem.OnHealthDecrease -= HealthSystem_OnHealthDecrease;
            healthSystem.OnDeath -= HealthSystem_OnDeath;
        }
    }
}