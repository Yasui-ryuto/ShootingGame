using UnityEngine;

public class EnemyBullet_Wave : BaseEnemyBullet
{
    private float _startTime;
    private Vector2 _startPos;

    [Header("‰¡‚Ì‘å‚«‚³")]
    [SerializeField] private float _amplitude = 2f;
    [Header("c‚Ì‘¬‚³")]
    [SerializeField] private float _verticalSpeed = 2f;
    [Header("üŠú")]
    [SerializeField] private float _frequency = 2f;

    private void Awake()
    {
        _startPos = transform.position;
    }

    protected override void Start()
    {
        base.Start();
        _startTime = Time.time;
    }

    private void Update()
    {
        MoveBullet();
    }

    protected override void MoveBullet()
    {
        transform.position = 
            new Vector2(Mathf.Sin((_startTime - Time.time) * _frequency) * _amplitude, (_startTime - Time.time) * _verticalSpeed) + _startPos;
    }
}
