using UnityEngine;

//using XLua;
/// <inheritdoc />
/// <summary>
/// 普通鱼的类
/// </summary>
//[Hotfix]
public class Fish : MonoBehaviour
{
    //属性
    public float moveSpeed = 2;
    public int GetCold = 10;
    public int GetDiamonds = 10;
    public int hp = 5;

    //计时器
    private float rotateTime;
    private float timeVal;

    //引用
    public GameObject gold;
    public GameObject diamonds;
    private GameObject fire;
    private GameObject ice;
    private Animator iceAni;
    private Animator gameObjectAni;
    private SpriteRenderer sr;
    public GameObject pao;

    //开关
    private bool hasIce;
    public bool isNet;
    private bool isDead;
    public bool cantRotate;

    private void Start()
    {
        fire = transform.Find("Fire").gameObject;
        ice = transform.Find("Ice").gameObject;
        iceAni = ice.transform.GetComponent<Animator>();
        gameObjectAni = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        Destroy(gameObject, 20);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeVal >= 14 || isDead)
        {
            sr.color -= new Color(0, 0, 0, Time.deltaTime);
        }
        else
        {
            timeVal += Time.deltaTime;
        }

        if (isDead)
        {
            return;
        }

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

        //灼烧方法
        fire.SetActive(Gun.Instance.Fire);

        if (Gun.Instance.Ice)
        {
            return;
        }

        if (isNet)
        {
            Invoke("Net", 0.5f);
            return;
        }

        fishMove();
    }

    public void Net()
    {
        if (isNet)
        {
            isNet = false;
        }
    }

    public void fishMove()
    {
        transform.Translate(transform.right * moveSpeed * Time.deltaTime, Space.World);
        if (cantRotate)
        {
            return;
        }

        if (rotateTime >= 5)
        {
            transform.Rotate(transform.forward * Random.Range(0, 361), Space.World);
            rotateTime = 0;
        }
        else
        {
            rotateTime += Time.deltaTime;
        }
    }

//    [LuaCallCSharp]
    public void TakeDamage(int attackValue)
    {
        if (Gun.Instance.Fire)
        {
            attackValue *= 2;
        }

        hp -= attackValue;
        if (hp <= 0)
        {
            isDead = true;
            for (int i = 0; i < 9; i++)
            {
                Instantiate(pao, transform.position, Quaternion.Euler(transform.eulerAngles + new Vector3(0, 45 * i, 0)));
            }

            gameObjectAni.SetTrigger("Die");
            Invoke("Prize", 0.7f);
        }
    }

    private void Prize()
    {
        Gun.Instance.GoldChange(GetCold);
        if (GetDiamonds != 0)
        {
            Gun.Instance.DiamandsChange(GetDiamonds);
            Instantiate(diamonds, transform.position, transform.rotation);
        }

        Instantiate(gold, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}