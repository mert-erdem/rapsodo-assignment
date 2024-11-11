using System;
using System.Collections.Generic;
using Game.Scripts.Core;
using Game.Scripts.Environment;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Scripts.Managers
{
    /// <summary>
    /// Controls golf balls and golf cart
    /// </summary>
    public sealed class EnvironmentManager : Singleton<EnvironmentManager>
    {
        [SerializeField] private Transform golfCartInteractionTransform;
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

        public Vector3 GetGolfCartPosition()
        {
            return golfCartInteractionTransform.transform.position;
        }

        private void GolfBall_OnGathered(object sender, EventArgs eventArgs)
        {
            GolfBall golfBall = sender as GolfBall;
            golfBalls.Remove(golfBall);
            
            if (golfBall != null) Destroy(golfBall.gameObject);
        }
    }
}
