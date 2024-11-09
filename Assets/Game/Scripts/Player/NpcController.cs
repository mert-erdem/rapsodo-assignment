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

        private GolfBall _currentTarget;
        
        private void SetTarget(GolfBall target)
        {
            agent.SetDestination(target.GetPosition());
        }
    }
}
