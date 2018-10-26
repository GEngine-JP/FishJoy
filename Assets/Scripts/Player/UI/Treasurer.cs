using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

//using XLua;
/// <summary>
/// 宝藏
/// </summary>
//[Hotfix]
public class Treasurer : MonoBehaviour
{
    private Button but;
    private Image img;

    public GameObject gold;
    public GameObject diamonds;
    public GameObject cdView;

    public Transform trans;
    private bool isDrease;


    private void Awake()
    {
        but = GetComponent<Button>();
        but.onClick.AddListener(OpenTreasurer);
        img = GetComponent<Image>();
    }

    void OpenTreasurer()
    {
        if (Math.Abs(img.color.a - 1) > 1)
        {
            return;
        }

        cdView.SetActive(true);
        Gun.Instance.GoldChange(Random.Range(100, 200));
        Gun.Instance.DiamandsChange(Random.Range(10, 50));
        CreatePrize();
        isDrease = true;
    }

//    [LuaCallCSharp]
    private void CreatePrize()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject go = Instantiate(gold, transform.position + new Vector3(-10f + i * 30, 0, 0), transform.rotation);
            go.transform.SetParent(trans);
            GameObject go1 = Instantiate(diamonds, transform.position + new Vector3(0, 30, 0) + new Vector3(-10f + i * 30, 0, 0), transform.rotation);
            go1.transform.SetParent(trans);
        }
    }

    private void Update()
    {
        if (isDrease)
        {
            img.color -= new Color(0, 0, 0, Time.deltaTime * 10);
            if (img.color.a <= 0.2)
            {
                img.color = new Color(img.color.r, img.color.g, img.color.b, 0);
                isDrease = false;
            }
        }
        else
        {
            img.color += new Color(0, 0, 0, Time.deltaTime * 0.01f);
            if (img.color.a >= 0.9)
            {
                img.color = new Color(img.color.r, img.color.g, img.color.b, 1);
                cdView.SetActive(false);
            }
        }
    }
}