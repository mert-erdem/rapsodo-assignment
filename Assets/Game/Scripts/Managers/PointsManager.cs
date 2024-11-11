using System;
using System.Collections.Generic;
using System.Linq;
using Game.Scripts.Core;
using Game.Scripts.Environment;

namespace Game.Scripts.Managers
{
    public sealed class PointsManager : Singleton<PointsManager>
    {
        /// <summary>
        /// This data structure used due to further RC usages
        /// </summary>
        private readonly Dictionary<GolfBallLevel, int> _golfBallPoints = new()
        {
            {
                GolfBallLevel.Easy,
                5
            },
            {
                GolfBallLevel.Moderate,
                10
            },
            {
                GolfBallLevel.Challenging,
                15
            }
        };
        
        private readonly Dictionary<GolfBallLevel, float> _golfBallPointsNormalized = new();

        private int _currentPoints;
        public event EventHandler<int> OnCurrentPointsChanged;

        protected override void Awake()
        {
            base.Awake();

            // Fill the normalized golf ball points dictionary
            int totalPoints = _golfBallPoints.Sum(x => x.Value);

            foreach (KeyValuePair<GolfBallLevel, int> keyValuePair in _golfBallPoints)
            {
                _golfBallPointsNormalized.Add(keyValuePair.Key, (float) keyValuePair.Value / totalPoints);
            }
        }
        
        public float GetGolfBallPointsNormalized(GolfBallLevel golfBallLevel)
        {
            return _golfBallPointsNormalized[golfBallLevel];
        }

        public void AddPoints(GolfBallLevel golfBallLevel)
        {
            _currentPoints += _golfBallPoints[golfBallLevel];
            OnCurrentPointsChanged?.Invoke(this, _currentPoints);
        }

        public float GetCurrentPoints()
        {
            return _currentPoints;
        }
    }
}
