using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <inheritdoc />
/// <summary>
/// 加载游戏
/// </summary>
public class LoadGame : MonoBehaviour
{
    public Slider processView;

    private void Start()
    {
        LoadGameMethod();
    }


    public void LoadGameMethod()
    {
        StartCoroutine(LoadResourceCorotine());
        StartCoroutine(StartLoading(2));
    }

    private IEnumerator StartLoading(int scene)
    {
        int displayProgress = 0;
        int toProgress = 0;
        AsyncOperation op = SceneManager.LoadSceneAsync(scene);
        op.allowSceneActivation = false;
        while (op.progress < 0.9f)
        {
            toProgress = (int) op.progress * 100;
            while (displayProgress < toProgress)
            {
                ++displayProgress;
                SetLoadingPercentage(displayProgress);
                yield return new WaitForEndOfFrame();
            }
        }

        toProgress = 100;
        while (displayProgress < toProgress)
        {
            ++displayProgress;
            SetLoadingPercentage(displayProgress);
            yield return new WaitForEndOfFrame();
        }

        op.allowSceneActivation = true;
    }

    IEnumerator LoadResourceCorotine()
    {
        UnityWebRequest request = UnityWebRequest.Get(@"http://localhost/fish.lua.txt");
        yield return request.SendWebRequest();
        string str = request.downloadHandler.text;
        File.WriteAllText(@"C:\Users\Administrator\Desktop\XluaProjects\PlayerGamePackage\fish.lua.txt", str);
        UnityWebRequest request1 = UnityWebRequest.Get(@"http://localhost/fishDispose.lua.txt");
        yield return request1.SendWebRequest();
        string str1 = request1.downloadHandler.text;
        File.WriteAllText(@"C:\Users\Administrator\Desktop\XluaProjects\PlayerGamePackage\fishDispose.lua.txt", str1);
    }

    private void SetLoadingPercentage(float v)
    {
        processView.value = v / 100;
    }
}