using UnityEngine;

public class EnemyBullet_Wave : BaseEnemyBullet
{
    private float _startTime;
    private Vector2 _startPos;

    [Header("横の大きさ")]
    [SerializeField] private float _amplitude = 2f;
    [Header("縦の速さ")]
    [SerializeField] private float _verticalSpeed = 2f;
    [Header("周期")]
    [SerializeField] private float _frequency = 2f;

    [Header("全体的なスピード")]
    [SerializeField] private float _speed = 5f;


    protected override void Start()
    {
        base.Start();
        _startPos = transform.position;
        _startTime = Time.time * _speed;
    }

    private void Update()
    {
        MoveBullet();
    }

    protected override void MoveBullet()
    {
        float elapsed = Time.time * _speed - _startTime;
        float x = Mathf.Sin((elapsed) * _frequency) * _amplitude;
        float y = -elapsed * _verticalSpeed;

        transform.position = new Vector2(x, y) + _startPos;
    }
}
