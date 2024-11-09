using UnityEngine;

namespace Game.Scripts.Environment
{
    public sealed class GolfBall : MonoBehaviour
    {
        [SerializeField] private GolfBallLevel level;

        public GolfBallLevel Level => level;

        private float _distanceToNpc;
        
        public Vector3 GetPosition() => transform.position;

        public void SetDistanceToNpc(float distance)
        {
            _distanceToNpc = distance;
        }

        public float GetDistanceToNpc()
        {
            return _distanceToNpc;
        }
    }
}