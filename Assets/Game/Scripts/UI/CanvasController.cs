using Game.Scripts.Core;
using Game.Scripts.Managers;
using UnityEngine;

namespace Game.Scripts.UI
{
    public sealed class CanvasController : Singleton<CanvasController>
    {
        [SerializeField] private PanelInGame panelInGame;
        [SerializeField] private PanelMainMenu panelMainMenu;

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
            panelMainMenu.gameObject.SetActive(false);
            panelInGame.gameObject.SetActive(true);
        }

        private void OnDestroy()
        {
            GameManager.Instance.OnGameStart -= OnGameStart;
        }
    }
}
