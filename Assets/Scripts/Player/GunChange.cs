using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 切枪的按钮
/// </summary>
public class GunChange : MonoBehaviour
{
    public bool add;
    private Button button;
    private Image image;
    public Sprite[] buttonSprites; //0.+   1.灰色的+  2.-  3.灰色的-

    // Use this for initialization
    void Start()
    {
        button = transform.GetComponent<Button>();
        button.onClick.AddListener(ChangeGunLevel);
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Gun.Instance.canChangeGun)
        {
            image.sprite = add ? buttonSprites[0] : buttonSprites[2];
        }
    }

    public void ChangeGunLevel()
    {
        if (Gun.Instance.canChangeGun)
        {
            if (add)
            {
                Gun.Instance.UpGun();
            }
            else
            {
                Gun.Instance.DownGun();
            }
        }
    }

    public void ToGray()
    {
        image.sprite = add ? buttonSprites[1] : buttonSprites[3];
    }
}