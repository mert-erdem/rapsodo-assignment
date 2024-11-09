using System.Collections.Generic;
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
                20
            }
        };

        public int GetGolfBallPoints(GolfBallLevel golfBallLevel)
        {
            return _golfBallPoints[golfBallLevel];
        }
    }
}
