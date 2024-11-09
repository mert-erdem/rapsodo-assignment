using Game.Scripts.Environment;
using Game.Scripts.Managers;
using UnityEngine;

namespace Game.Scripts.Player
{
    /// <summary>
    /// Decision-making brain.
    /// Chooses a golf ball for NPC to gather with using weighted distance algorithm.
    /// Also uses NPC's health percentage in balancing weights of the properties.
    /// </summary>
    public class DecisionMaker : MonoBehaviour
    {
        [SerializeField] private NpcController controller;
        [SerializeField] private Health health;

        private GolfBall[] _golfBalls;
        private float[] _scores;

        private float _pointsWeight;
        private float _distanceWeight;
        
        private GolfBall _currentTarget;

        private void Start()
        {
            _golfBalls = GolfBallsManager.Instance.GetGolfBalls();
            _scores = new float[_golfBalls.Length];
            
            CalculateGolfBallDistances();
            // TODO: First choose can be random
            SelectTargetGolfBall();
        }

        private void SelectTargetGolfBall()
        {
            CalculateScores();
            controller.SetTarget(_currentTarget);
        }

        private void CalculateGolfBallDistances()
        {
            for (int i = 0; i < _golfBalls.Length; i++)
            {
                float distance = controller.CalculateDistanceToTarget(_golfBalls[i].GetPosition());
                _golfBalls[i].SetDistanceToNpc(distance);
            }
        }

        private void CalculateScores()
        {
            // TODO: Stop decreasing the health

            // Balancing weights via current health percentage (distance's importance increase over time)
            _pointsWeight = health.GetCurrentHealthPercentage();
            _distanceWeight = 1 - _pointsWeight;
            
            float maxScore = 0;
            
            for (int i = 0; i < _scores.Length; i++)
            {
                _scores[i] = _pointsWeight * PointsManager.Instance.GetGolfBallPointsNormalized(_golfBalls[i].Level) +
                             _distanceWeight * (1 / _golfBalls[i].GetDistanceToNpc());
                
                if (_scores[i] >= maxScore)
                {
                    maxScore = _scores[i];
                    _currentTarget = _golfBalls[i];
                }
            }
        }
    }
}