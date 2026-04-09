using UnityEngine;

public class EnemyBullet_Rotation : BaseEnemyBullet
{
    [Header("速度")]
    [SerializeField] private float _speed = 5f;

    [Header("角度の増える度合い")]
    [SerializeField] private float _increaseRotateAngle = 0.1f;

    //最終的な角度
    private Vector2 _angle;

    private Rigidbody2D _rb;

    //弾全員で現在のRotateの角度を共有
    public static float nowRotate = 0;

    protected virtual void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        SetRotateAngle();
    }

    private void FixedUpdate()
    {
        MoveBullet();
    }

    protected override void MoveBullet()
    {
        _rb.linearVelocity = _angle.normalized * _speed;
    }

    private void SetRotateAngle()
    {
        nowRotate += _increaseRotateAngle;

        float x = Mathf.Sin(nowRotate);
        float y = Mathf.Cos(nowRotate);
        
        _angle = new Vector2(x, y);
    }
}