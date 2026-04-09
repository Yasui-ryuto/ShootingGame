using UnityEngine;

public class BasePlayerBullet : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 5f;

    private void Start()
    {
        Destroy(gameObject, _lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
