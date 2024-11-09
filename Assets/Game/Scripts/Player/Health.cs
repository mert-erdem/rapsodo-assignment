using System;
using UnityEngine;

namespace Game.Scripts.Player
{
    public sealed class Health : MonoBehaviour
    {
        [SerializeField] [Range(1f, 100f)] private float health = 100f;
        public event EventHandler OnDeath;

        private const float HEALTH_DECREASE_DELTA = 1.5f;
        private const float HEALTH_DECREASE_DELTA_SECONDS = 1f;
        
        private float _currentHealth;
        private float _currentDecreaseDeltaSeconds;

        private void Awake()
        {
            _currentDecreaseDeltaSeconds = HEALTH_DECREASE_DELTA_SECONDS;
        }

        private void Update()
        {
            if (_currentHealth <= 0) return;
            
            _currentDecreaseDeltaSeconds -= Time.deltaTime;
            
            if (_currentDecreaseDeltaSeconds > 0) return;
        
            _currentHealth = Mathf.Max(_currentHealth - HEALTH_DECREASE_DELTA, 0);
            _currentDecreaseDeltaSeconds = HEALTH_DECREASE_DELTA_SECONDS;

            if (_currentHealth == 0)
            {
                Die();
            }
        }

        public float GetCurrentHealthPercentage()
        {
            return _currentHealth / health;
        }

        private void Die()
        {
            OnDeath?.Invoke(this, EventArgs.Empty);
        }
    }
}
