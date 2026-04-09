using UnityEngine;
using System.Collections;

public class BaseShotBullet : MonoBehaviour
{
    [SerializeField] protected GameObject _bullet;
    [SerializeField] protected float _bulletSpeed = 10f;
    [SerializeField] protected float _intervalTime = 0.2f;

    protected Vector2 _shotDirection;

    private bool _isInterval = false;

    protected virtual void Start()
    {

    }

    protected virtual void FixedUpdate()
    {
        if (!_isInterval)
        {
            StartCoroutine(ShotBullet());
        }
    }

    protected virtual IEnumerator ShotBullet()
    {
        _isInterval = true;

        GameObject bullet = Instantiate(_bullet, transform.position, Quaternion.identity);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

        if (bulletRb != null)
        {
            bulletRb.linearVelocity = _shotDirection * _bulletSpeed;
        }
        else
        {
            Destroy(bullet);
        }

        yield return new WaitForSeconds(_intervalTime);

        _isInterval = false;
    }
}