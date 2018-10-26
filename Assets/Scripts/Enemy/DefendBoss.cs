using UnityEngine;

//using XLua;
/// <inheritdoc />
/// <summary>
/// 有护盾的boss
/// </summary>
//[Hotfix]
public class DefendBoss : Boss
{
    private bool isDefend;

    private float defendTime;

    public GameObject defend;


//	[LuaCallCSharp]
    void Start()
    {
        fire = transform.Find("Fire").gameObject;
        ice = transform.Find("Ice").gameObject;
        iceAni = ice.transform.GetComponent<Animator>();
        gameObjectAni = GetComponent<Animator>();
        bossAudio = GetComponent<AudioSource>();
        playerTransform = Gun.Instance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //冰冻效果
        if (Gun.Instance.Ice)
        {
            gameObjectAni.enabled = false;
            ice.SetActive(true);
            if (!hasIce)
            {
                iceAni.SetTrigger("Ice");
                hasIce = true;
            }
        }
        else
        {
            gameObjectAni.enabled = true;
            hasIce = false;
            ice.SetActive(false);
        }

        //灼烧效果
        if (Gun.Instance.Fire)
        {
            fire.SetActive(true);
        }
        else
        {
            fire.SetActive(false);
        }

        if (Gun.Instance.Ice)
        {
            return;
        }

        //boss的行为方法
        Attack(m_reduceGold, m_reduceDiamond);
        if (!isAttack)
        {
            fishMove();
        }

        //保护方法
        if (defendTime >= 10)
        {
            defendTime = 0;
            DeffenMe();
        }
        else
        {
            defendTime += Time.deltaTime;
        }
    }

    void DeffenMe()
    {
        isDefend = true;
        defend.SetActive(true);
        Invoke("CloseDeffendMe", 3);
    }

    private void CloseDeffendMe()
    {
        defend.SetActive(false);
        isDefend = false;
    }

    public override void TakeDamage(int attackValue)
    {
        if (isDefend)
        {
            return;
        }

        base.TakeDamage(attackValue);
    }
}