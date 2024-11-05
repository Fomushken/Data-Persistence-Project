using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public class MenuUIHandler : MonoBehaviour
{
    private string _playerName;
    [SerializeField] private TextMeshProUGUI playerNameText;
    [SerializeField] private TextMeshProUGUI bestScoreText;

    void Start()
    {
        if (DataManager.Instance != null && DataManager.Instance.bestScore > 0)
        {
            bestScoreText.text = $"Best Score: {DataManager.Instance.bestPlayerName} : {DataManager.Instance.bestScore}";
        }
        else
        {
            bestScoreText.text = "No Best Score Yet";
        }
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        _playerName = playerNameText.text;
        DataManager.Instance.currentPlayer = new DataManager.Player();
        DataManager.Instance.currentPlayer.PlayerName = _playerName;
    }

    public void QuitGame()
    {
        DataManager.Instance.Save();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void ClearData()
    {
        DataManager.Instance.Delete();
    }
}
