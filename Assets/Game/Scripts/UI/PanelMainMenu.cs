using Game.Scripts.Managers;
using UnityEngine;

namespace Game.Scripts.UI
{
    public sealed class PanelMainMenu : MonoBehaviour
    {
        public void OnButtonStartPointerDown()
        {
            GameManager.Instance.OnGameStart?.Invoke();
        }
    }
}
