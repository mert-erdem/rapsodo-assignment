using Game.Scripts.Core;
using Game.Scripts.Environment;
using UnityEngine;

public sealed class GolfBallsManager : Singleton<GolfBallsManager>
{
    [SerializeField] private GolfBall[] golfBalls;

    public GolfBall[] GetGolfBalls()
    {
        return golfBalls;
    }
}
