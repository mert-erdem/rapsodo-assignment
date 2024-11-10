using System.Collections.Generic;
using Game.Scripts.Environment;
using Game.Scripts.Managers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Scripts.Player
{
    /// <summary>
    /// Decision-making brain.
    /// Chooses a golf ball for NPC to gather with using weighted distance algorithm.
    /// Also uses NPC's health percentage in balancing weights of the properties.
    /// </summary>
    public sealed class DecisionMaker : MonoBehaviour
    {
        [SerializeField] private NpcController npcController;
        [SerializeField] private HealthSystem healthSystem;

        private List<GolfBall> _golfBalls;

        private float _pointsWeight;
        private float _distanceWeight;
        
        private GolfBall _currentTarget;

        private void Start()
        {
            _golfBalls = EnvironmentManager.Instance.GetGolfBalls();
            GameManager.Instance.OnGameStart += OnGameStart;
        }

        private void SelectTargetGolfBall(bool random = false)
        {
            healthSystem.SetDecrease(false); // to get exact health value (decreasing health only while walking)
            _currentTarget = random ? _golfBalls[Random.Range(0, _golfBalls.Count)] : FindOptimalGolfBall();
            npcController.SetTargetPos(_currentTarget.GetPosition());
            healthSystem.SetDecrease(true);
        }

        private void CalculateGolfBallDistances()
        {
            for (int i = 0; i < _golfBalls.Count; i++)
            {
                float distance = npcController.CalculateDistanceToTarget(_golfBalls[i].GetPosition());
                _golfBalls[i].SetDistanceToNpc(distance);
            }
        }

        private GolfBall FindOptimalGolfBall()
        {
            // Balancing weights via current health percentage (distance's importance increase over time)
            _pointsWeight = healthSystem.GetCurrentHealthPercentage();
            _distanceWeight = 1 - _pointsWeight;
            
            float maxScore = 0;
            GolfBall selectedGolfBall = _golfBalls[0];
            
            for (int i = 0; i < _golfBalls.Count; i++)
            {
                float score = _pointsWeight * PointsManager.Instance.GetGolfBallPointsNormalized(_golfBalls[i].Level) +
                             _distanceWeight * (1 / _golfBalls[i].GetDistanceToNpc());
                
                if (score >= maxScore)
                {
                    maxScore = score;
                    selectedGolfBall = _golfBalls[i];
                }
            }

            return selectedGolfBall;
        }

        private void OnGameStart()
        {
            CalculateGolfBallDistances();
            // First choose is random to creating different cases
            SelectTargetGolfBall(true);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Target"))
            {
                // Golf ball has been gathered
                // Later golf cart can be dynamic (caching ignored)
                npcController.SetTargetPos(EnvironmentManager.Instance.GetGolfCarPosition());
            }
            else if (other.CompareTag("Base"))
            {
                // Golf ball has reached the cart
                // Add points;
                PointsManager.Instance.AddPoints(_currentTarget.Level);
                // Select new golf ball as target;
                SelectTargetGolfBall();
            }
        }

        private void OnDestroy()
        {
            GameManager.Instance.OnGameStart -= OnGameStart;
        }
    }
}