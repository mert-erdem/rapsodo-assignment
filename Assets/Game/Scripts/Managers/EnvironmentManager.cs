using System;
using System.Collections.Generic;
using Game.Scripts.Core;
using Game.Scripts.Environment;
using UnityEngine;

namespace Game.Scripts.Managers
{
    public sealed class EnvironmentManager : Singleton<EnvironmentManager>
    {
        [SerializeField] private Transform golfCarInteractionTransform;
        [SerializeField] private List<GolfBall> golfBalls;
        
        protected override void Awake()
        {
            base.Awake();

            foreach (GolfBall golfBall in golfBalls)
            {
                golfBall.OnGathered += GolfBall_OnGathered;
            }
        }

        public List<GolfBall> GetGolfBalls()
        {
            return golfBalls;
        }

        public Vector3 GetGolfCarPosition()
        {
            return golfCarInteractionTransform.transform.position;
        }

        private void GolfBall_OnGathered(object sender, EventArgs eventArgs)
        {
            GolfBall golfBall = sender as GolfBall;
            golfBalls.Remove(golfBall);
            Destroy(golfBall.gameObject);
        }
    }
}
