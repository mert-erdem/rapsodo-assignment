using Game.Scripts.Core;
using Game.Scripts.Managers;
using UnityEngine;

namespace Game.Scripts.UI
{
    public sealed class CanvasController : Singleton<CanvasController>
    {
        [SerializeField] private PanelInGame panelInGame;

        private void Start()
        {
            GameManager.Instance.OnGameStart += OnGameStart;
        }

        public void UpdateHealthBar(float currentHealthPercentage)
        {
            panelInGame.UpdateHealthBar(currentHealthPercentage);
        }

        private void OnGameStart()
        {
            panelInGame.gameObject.SetActive(true);
        }
    }
}
