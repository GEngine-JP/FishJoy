using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 挡子弹的气泡
/// </summary>
public class Qipao : MonoBehaviour
{
    //属性
    public float moveSpeed = 2;


    //计时器
    private float rotateTime;

    private void Start()
    {
        Destroy(gameObject, 14);
    }

    private void Update()
    {
        fishMove();
    }

    public void fishMove()
    {
        transform.Translate(transform.right * moveSpeed * Time.deltaTime, Space.World);
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
}