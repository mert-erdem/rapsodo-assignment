using System;
using UnityEngine;

namespace Game.Scripts.Environment
{
    public sealed class GolfBall : MonoBehaviour
    {
        [SerializeField] private GolfBallLevel level;

        public GolfBallLevel Level => level;

        public event EventHandler OnGathered;

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

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                OnGathered?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}