using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    private string _playerName;
    [SerializeField] private TextMeshProUGUI playerNameText; 
    
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        _playerName = playerNameText.text;
        DataManager.Instance.playerName = _playerName;
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
