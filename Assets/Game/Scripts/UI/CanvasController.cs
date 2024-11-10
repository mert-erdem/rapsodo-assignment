using Game.Scripts.Core;
using Game.Scripts.Managers;
using UnityEngine;

namespace Game.Scripts.UI
{
    public sealed class CanvasController : Singleton<CanvasController>
    {
        [SerializeField] private PanelMainMenu panelMainMenu;
        [SerializeField] private PanelInGame panelInGame;
        [SerializeField] private PanelGameOver panelGameOver;

        private void Start()
        {
            GameManager.Instance.OnGameStart += OnGameStart;
            GameManager.Instance.OnGameOver += OnGameOver;
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

        private void OnGameOver()
        {
            panelInGame.gameObject.SetActive(false);
            panelGameOver.gameObject.SetActive(true);
        }

        private void OnDestroy()
        {
            GameManager.Instance.OnGameStart -= OnGameStart;
            GameManager.Instance.OnGameOver -= OnGameOver;
        }
    }
}
