using System;
using UnityEngine;

namespace Game.Scripts.Player
{
    public sealed class HealthSystem : MonoBehaviour
    {
        [SerializeField] [Range(1f, 100f)] private float health = 100f;
        
        [Header("Decrease Properties")]
        [SerializeField] [Range(0.1f, 100f)] private float healthDecreaseDelta = 5f;
        [SerializeField] [Range(0.1f, 10f)] private float healthDecreaseDeltaSeconds = 1.5f;
        
        public event EventHandler<float> OnHealthDecrease;
        public event EventHandler OnDeath;
        
        private float _currentHealth;
        private float _currentDecreaseDeltaSeconds;
        private bool _isDecreasing;

        private void Awake()
        {
            _currentHealth = health;
            _currentDecreaseDeltaSeconds = healthDecreaseDeltaSeconds;
        }

        private void Update()
        {
            if (!_isDecreasing) return;
            
            if (_currentHealth <= 0) return;
            
            _currentDecreaseDeltaSeconds -= Time.deltaTime;
            
            if (_currentDecreaseDeltaSeconds > 0) return;
            
            DecreaseHealth();
            
            if (_currentHealth == 0) Die();
        }

        public float GetCurrentHealthPercentage()
        {
            return _currentHealth / health;
        }
        
        public void SetDecrease(bool value)
        {
            _isDecreasing = value;
            _currentDecreaseDeltaSeconds = healthDecreaseDeltaSeconds;
        }

        private void DecreaseHealth()
        {
            _currentHealth = Mathf.Max(_currentHealth - healthDecreaseDelta, 0);
            OnHealthDecrease?.Invoke(this, GetCurrentHealthPercentage());
            _currentDecreaseDeltaSeconds = healthDecreaseDeltaSeconds;
        }

        private void Die()
        {
            OnDeath?.Invoke(this, EventArgs.Empty);
        }
    }
}
