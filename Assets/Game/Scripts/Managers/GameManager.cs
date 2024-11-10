using System;
using Game.Scripts.Core;

namespace Game.Scripts.Managers
{
    public sealed class GameManager : Singleton<GameManager>
    {
        public Action OnGameStart, OnGameOver;
    }
}
