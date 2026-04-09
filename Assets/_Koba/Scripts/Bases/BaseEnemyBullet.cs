using UnityEngine;

public abstract class BaseEnemyBullet : MonoBehaviour
{
    [SerializeField] protected float _lifeTime = 5f;

    protected virtual void Start()
    {
        Destroy(gameObject, _lifeTime);
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    protected abstract void MoveBullet();
}
