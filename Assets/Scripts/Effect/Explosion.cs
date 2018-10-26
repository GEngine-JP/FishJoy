using UnityEngine;

/// <inheritdoc />
/// <summary>
/// 爆炸特效
/// </summary>
public class Explosion : MonoBehaviour
{
    public float DestroyTime = 0.2f;

    private void Start()
    {
        Destroy(gameObject, DestroyTime);
    }

    private void Update()
    {
        transform.localScale += new Vector3(Time.deltaTime * 10, Time.deltaTime * 10, Time.deltaTime * 10);
    }
}