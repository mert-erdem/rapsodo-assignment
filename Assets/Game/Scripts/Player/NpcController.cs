using System;
using Game.Scripts.Managers;
using Game.Scripts.UI;
using UnityEngine;
using UnityEngine.AI;

namespace Game.Scripts.Player
{
    /// <summary>
    /// Handles NPC's movement
    /// </summary>
    [SelectionBase]
    [RequireComponent(typeof(NavMeshAgent))]
    public sealed class NpcController : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private HealthSystem healthSystem;

        private NavMeshPath _path;

        private void Awake()
        {
            _path = new NavMeshPath();
            healthSystem.OnHealthDecrease += HealthSystem_OnHealthDecrease;
            healthSystem.OnDeath += HealthSystem_OnDeath;
        }

        private void Start()
        {
            // Update UI
            CanvasController.Instance.UpdateHealthBar(healthSystem.GetCurrentHealthPercentage());
        }

        public void SetTargetPos(Vector3 pos)
        {
            agent.SetDestination(pos);
        }
        
        public float CalculateDistanceToTarget(Vector3 targetPos)
        {
            agent.CalculatePath(targetPos, _path);
            
            float pathLength = 0f;
            
            if (_path.status == NavMeshPathStatus.PathComplete)
            {
                for (int i = 1; i < _path.corners.Length; i++)
                {
                    pathLength += Vector3.Distance(_path.corners[i - 1], _path.corners[i]);
                }
            }

            return pathLength;
        }

        private void HealthSystem_OnDeath(object sender, EventArgs eventArgs)
        {
            agent.isStopped = true;
            GameManager.Instance.OnGameOver?.Invoke();
        }

        private void HealthSystem_OnHealthDecrease(object sender, float currentHealthPercentage)
        {
            // Update UI
            CanvasController.Instance.UpdateHealthBar(currentHealthPercentage);
        }

        private void OnDestroy()
        {
            healthSystem.OnDeath -= HealthSystem_OnDeath;
        }
    }
}
