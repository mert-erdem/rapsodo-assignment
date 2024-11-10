using Game.Scripts.Managers;
using UnityEngine;

public sealed class PanelGameOver : MonoBehaviour
{
    public void OnButtonRestartClick()
    {
        GameManager.Instance.RestartLevel();
    }
}
