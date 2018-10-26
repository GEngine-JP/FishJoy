using UnityEngine;
using UnityEngine.UI;

//using XLua;
/// <inheritdoc />
/// <summary>
/// 冰冻
/// </summary>
//[Hotfix]
public class Ice : MonoBehaviour
{
    private float timeVal = 10;
    private bool canUse = true;

    public Slider cdSlider;
    private float totalTime = 10;
    Button but;
    private AudioSource fireAudio;

    private int reduceDiamonds;

    private void Awake()
    {
        but = transform.GetComponent<Button>();
        but.onClick.AddListener(ice);
        fireAudio = GetComponent<AudioSource>();
    }


    private void Start()
    {
        reduceDiamonds = 10;
    }

    private void Update()
    {
        if (timeVal >= 10)
        {
            timeVal = 10;
        }

        cdSlider.value = timeVal / totalTime;
        if (timeVal >= 10)
        {
            cdSlider.transform.Find("Background").gameObject.SetActive(false);
            canUse = true;
        }
        else
        {
            timeVal += Time.deltaTime;
        }
    }

    private void ice()
    {
        //必杀的方法
        if (canUse)
        {
            if (!Gun.Instance.Fire && !Gun.Instance.Ice)
            {
                if (Gun.Instance.diamonds <= reduceDiamonds)
                {
                    return;
                }

                if (fireAudio.isPlaying)
                {
                    return;
                }

                fireAudio.Play();
                Gun.Instance.DiamandsChange(-reduceDiamonds);
                Gun.Instance.Ice = true;
                canUse = false;
                cdSlider.transform.Find("Background").gameObject.SetActive(true);
                timeVal = 0;
                Invoke("CloseIce", 4);
            }
        }
    }

    //关闭必杀的方法
    private void CloseIce()
    {
        Gun.Instance.Ice = false;
    }
}