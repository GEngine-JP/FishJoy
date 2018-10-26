using UnityEngine;

/// <inheritdoc />
/// <summary>
/// 渔网
/// </summary>
public class FishNet : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 0.2f);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("fish"))
        {
            other.GetComponent<Fish>().isNet = true;
        }
    }
}