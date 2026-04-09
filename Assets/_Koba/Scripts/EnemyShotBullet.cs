using UnityEngine;
using System.Collections;

public class EnemyShotBullet : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _intervalTime = 0.2f;

    private bool _isInterval = false;

    private void FixedUpdate()
    {
        if (!_isInterval)
        {
            StartCoroutine(ShotBullet());
        }
    }

    //ê∂ê¨ÇÕÇ±Ç±Å@ÇªÇÃå„ÇÃãììÆÇÕBulleté©êgÇ…Ç‹Ç©ÇπÇÈ
    private IEnumerator ShotBullet()
    {
        _isInterval = true;
        Instantiate(_bullet, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(_intervalTime);
        _isInterval = false;
    }
}
