using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <inheritdoc />
/// <summary>
/// 开始游戏
/// </summary>
public class StartGame : MonoBehaviour
{
    private Button but;

    private void Start()
    {
        but = GetComponent<Button>();
        but.onClick.AddListener(StartGames);
    }

    private void StartGames()
    {
        SceneManager.LoadScene(1);
    }
}