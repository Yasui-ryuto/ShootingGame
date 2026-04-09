using UnityEngine;

public class EnemyBullet_Straight : BaseEnemyBullet
{
    [Header("速度")]
    [SerializeField] private float _speed = 5f;
    [Header("打つ人からみた角度")]
    [SerializeField] private float _angle_x;
    [SerializeField] private float _angle_y;

    //最終的な角度
    protected Vector2 _angle;

    private Rigidbody2D _rb;


    protected virtual void Awake()
    {
       _rb = GetComponent<Rigidbody2D>();

       _angle = new Vector2(_angle_x, _angle_y);
    }

    private void FixedUpdate()
    {
        MoveBullet();
    }

    protected override void MoveBullet()
    {
       _rb.linearVelocity = _angle.normalized * _speed;
    }

   
}
