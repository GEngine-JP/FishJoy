using UnityEngine;

/// <inheritdoc />
/// <summary>
/// 捕到贝壳的道具卡
/// </summary>
public class Card : MonoBehaviour
{
    public int num;

    public Sprite[] cards;

    private SpriteRenderer sr;

    private AudioSource audios;

    private void Start()
    {
        Destroy(gameObject, 1);
        audios = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = cards[num];
        audios.Play();
    }
}