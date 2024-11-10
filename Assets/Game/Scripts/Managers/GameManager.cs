using System;
using Game.Scripts.Core;
using UnityEngine.SceneManagement;

namespace Game.Scripts.Managers
{
    public sealed class GameManager : Singleton<GameManager>
    {
        public Action OnGameStart, OnGameOver;

        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
