using Game.Scripts.Environment;
using UnityEngine;
using UnityEngine.AI;

namespace Game.Scripts.Player
{
    [SelectionBase]
    [RequireComponent(typeof(NavMeshAgent))]
    public class NpcController : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent agent;

        private NavMeshPath _path;

        private void Awake()
        {
            _path = new NavMeshPath();
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

        public void SetTarget(GolfBall target)
        {
            agent.SetDestination(target.GetPosition());
        }
    }
}
