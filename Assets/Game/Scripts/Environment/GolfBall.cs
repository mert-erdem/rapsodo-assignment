using UnityEngine;

namespace Game.Scripts.Environment
{
    public sealed class GolfBall : MonoBehaviour
    {
        [SerializeField] private GolfBallLevel level;

        public GolfBallLevel Level => level;
    }
}