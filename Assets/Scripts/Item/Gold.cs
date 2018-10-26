using UnityEngine;

/// <inheritdoc />
/// <summary>
/// 金币，钻石
/// </summary>
public class Gold : MonoBehaviour
{
    public enum ThePlaceTo
    {
        gold,
        diamonds,
        imageGold,
        imageDiamonds
    }

    public ThePlaceTo thePlaceTo;
    private Transform playerTransform;
    public float moveSpeed = 3;
    public GameObject star2;

    private AudioSource audios;
    public AudioClip goldAudio;
    public AudioClip diamondsAudio;

    private float timeVal2;
    public float defineTime2;
    private float timeBecome;
    private float timeVal3;

    public bool bossPrize;

    private bool beginMove;

    // Use this for initialization
    private void Awake()
    {
        audios = GetComponent<AudioSource>();
        switch (thePlaceTo)
        {
            case ThePlaceTo.gold:
                playerTransform = Gun.Instance.goldPlace;
                audios.clip = goldAudio;
                break;
            case ThePlaceTo.diamonds:
                playerTransform = Gun.Instance.diamondsPlace;
                audios.clip = diamondsAudio;
                break;
            case ThePlaceTo.imageGold:
                playerTransform = Gun.Instance.imageGoldPlace;
                audios.clip = goldAudio;
                break;
            case ThePlaceTo.imageDiamonds:
                playerTransform = Gun.Instance.imageDiamondsPlace;
                audios.clip = diamondsAudio;
                break;
        }

        audios.Play();
    }


    private void Update()
    {
        if (timeBecome >= 0.5f)
        {
            beginMove = true;
        }
        else
        {
            timeBecome += Time.deltaTime;
        }

        if (beginMove)
        {
            transform.position = Vector3.Lerp(transform.position, playerTransform.position,
                1 / Vector3.Distance(transform.position, playerTransform.position) * Time.deltaTime * moveSpeed);
            if (thePlaceTo == ThePlaceTo.imageDiamonds || thePlaceTo == ThePlaceTo.imageGold)
            {
                if (Vector3.Distance(transform.position, playerTransform.position) <= 2)
                {
                    Destroy(gameObject);
                }

                return;
            }

            if (transform.position == playerTransform.position)
            {
                Destroy(gameObject);
            }

            timeVal2 = InistStar(timeVal2, defineTime2, star2);
        }
        else
        {
            transform.localScale += new Vector3(Time.deltaTime * 3, Time.deltaTime * 3, Time.deltaTime * 3);
            if (bossPrize)
            {
                if (timeVal3 <= 0.3f)
                {
                    timeVal3 += Time.deltaTime;
                    transform.Translate(transform.right * moveSpeed * Time.deltaTime, Space.World);
                }
            }
        }
    }


    private float InistStar(float timeVals, float defineTimes, GameObject stars)
    {
        if (timeVals >= defineTimes)
        {
            Instantiate(stars, transform.position,
                Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + Random.Range(-40f, 40f)));
            timeVals = 0;
        }
        else
        {
            timeVals += Time.deltaTime;
        }

        return timeVals;
    }
}