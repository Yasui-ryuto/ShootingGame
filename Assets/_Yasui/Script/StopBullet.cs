using UnityEngine;
using static GameManager;

public class StopBullet : MonoBehaviour
{
    private Vector3 firstPosition;
    private Vector3 velocity = Vector3.zero;

    private Vector3 secondPosition;
    private bool second = false;
    [SerializeField] private float secondMoveTime = 3.0f;
    private void Start()
    {
        float random = Random.Range(0, 360);
        firstPosition = new Vector3(transform.parent.transform.position.x + 1.5f * Mathf.Sin(random), transform.parent.transform.position.y + 1.5f * Mathf.Cos(random), 0.0f);
    }

    private void Update()
    {
        if (!second)
        {
            if (Vector3.Distance(transform.position, firstPosition) > 0.2f)
            {
                transform.position = Vector3.SmoothDamp(transform.position, firstPosition, ref velocity, 1.0f);
            }
            else
            {
                secondPosition = player.transform.position + (player.transform.position - transform.position) * 1.3f; // ƒvƒŒƒCƒ„[‚Ì•ûŒü‚ðŽæ“¾

                second = true;
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, secondPosition) > 1f)
            {
                transform.position = Vector3.SmoothDamp(transform.position, secondPosition, ref velocity, secondMoveTime);
                transform.Rotate(0.0f, 0.0f, Time.time);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
