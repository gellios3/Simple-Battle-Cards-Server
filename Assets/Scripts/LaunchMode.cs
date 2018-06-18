using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LaunchMode : MonoBehaviour
{
    /// <summary>
    /// Launch toggle
    /// </summary>
    [SerializeField] private Toggle _launchToggle;

    /// <summary>
    /// Start button
    /// </summary>
    [SerializeField] private Button _startButton;

    /// <summary>
    /// Get is server status
    /// </summary>
    /// <returns></returns>
    private bool IsServer()
    {
        return _launchToggle.isOn;
    }

    /// <summary>
    /// On enable
    /// </summary>
    private void OnEnable()
    {
        _startButton.OnClickAsObservable().Subscribe(p =>
        {
            SceneManager.LoadScene(IsServer() ? "ServerView" : "RoomList");
        });
    }

    /// <summary>
    /// Launch as client 
    /// </summary>
    private void LaunchClient()
    {
        var activeModePrefab = Resources.Load<GameObject>("Prefabs/Client");
        Instantiate(activeModePrefab);
    }
}