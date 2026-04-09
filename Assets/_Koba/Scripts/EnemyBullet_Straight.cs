using UnityEngine;

public class EnemyBullet_Straight : BaseEnemyBullet
{
    [Header("ë¨ìx")]
    [SerializeField] private float _speed = 5f;
    [Header("ë≈Ç¬êlÇ©ÇÁÇ›ÇΩäpìx")]
    [SerializeField] private float _angle_x;
    [SerializeField] private float _angle_y;
    private Vector2 _angle;

    [SerializeField] private bool _isWhip = false;

    private float _whipAngle_x;
    [SerializeField] private float _maxAngle = 0.7f;
    [SerializeField] private float _increaseAngle = 0.1f;

    private Rigidbody2D _rb;

    public static int direction = 1;
    public static float nowAngle = 0;

    private void Awake()
    {
       _rb = GetComponent<Rigidbody2D>();

        _angle = new Vector2(_angle_x, _angle_y);

        if (_isWhip)
        {
            SetAngle();
        }
       
    }

    private void FixedUpdate()
    {
        MoveBullet();
    }

    protected override void MoveBullet()
    {
       _rb.linearVelocity = _angle.normalized * _speed;
    }

    private void SetAngle()
    {
        if(direction == 1)
        {
            nowAngle += _increaseAngle;
        }
        else
        {
            nowAngle -= _increaseAngle;
        }
        Debug.Log(nowAngle);

        if(direction == 1 && _maxAngle <= nowAngle)
        {
            direction = -1;
        }
        else if(direction == -1 && nowAngle <= -_maxAngle)
        {
            direction = 1;
        }

        _whipAngle_x = nowAngle;
        _angle = new Vector2(_whipAngle_x, _angle.y);
    }
}
