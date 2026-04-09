using UnityEngine;
using System.Collections;

public class PlayerShotBullet : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _bulletSpeed = 10f;
    [SerializeField] private float _intervalTime = 0.2f;

    private bool _isInterval = false;


    private void FixedUpdate()
    {
        if (!_isInterval)
        {
            StartCoroutine(ShotBullet());
        }
    }

    private IEnumerator ShotBullet()
    {
        _isInterval = true;

        GameObject bullet = Instantiate(_bullet, transform.position, Quaternion.identity);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

        if (bulletRb != null)
        {
            bulletRb.linearVelocity = Vector2.up * _bulletSpeed;
        }
        else
        {
            Destroy(bullet);
        }

        yield return new WaitForSeconds(_intervalTime);

        _isInterval = false;
    }
}