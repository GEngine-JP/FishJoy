using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <inheritdoc />
/// <summary>
/// 返回主界面
/// </summary>
public class ReturnMain : MonoBehaviour
{
    private Button but;

    private void Start()
    {
        but = GetComponent<Button>();
        but.onClick.AddListener(StartGames);
    }

    public void StartGames()
    {
        SceneManager.LoadScene(0);
    }
}