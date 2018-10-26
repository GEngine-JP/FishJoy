using UnityEngine;

public class Pao : MonoBehaviour
{
    /// <summary>
    /// 游戏中产生的泡泡
    /// </summary>
    public int moveSpeed;

    public bool isGamePao;

    // Use this for initialization
    void Start()
    {
        if (isGamePao)
        {
            moveSpeed = Random.Range(2, 4);
            Destroy(gameObject, Random.Range(0.5f, 1f));
        }
        else
        {
            moveSpeed = Random.Range(40, 100);
            Destroy(gameObject, Random.Range(7f, 10f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-transform.right * moveSpeed * Time.deltaTime, Space.World);
    }
}