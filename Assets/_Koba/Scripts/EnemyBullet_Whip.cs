using UnityEngine;

public class EnemyBullet_Whip : EnemyBullet_Straight
{
    [Header("最大角度")]
    [SerializeField] private float _maxWhipAngle = 0.7f;
    [Header("Whipの角度の増える度合い")]
    [SerializeField] private float _increaseWhipAngle = 0.1f;

    //プラスならWhipの方向がプラス方向になる
    public static int whipDirection = 1;
    //弾全員で現在のWhipの角度を共有
    public static float nowWhipAngle = 0;

    protected override void Start()
    {
        base.Start();
        SetWhipAngle();
    }


    private void SetWhipAngle()
    {
        if (whipDirection == 1)
        {
            nowWhipAngle += _increaseWhipAngle;
        }
        else
        {
            nowWhipAngle -= _increaseWhipAngle;
        }

        //最大角度まで来たら折り返す
        if (whipDirection == 1 && _maxWhipAngle <= nowWhipAngle)
        {
            whipDirection = -1;
        }
        else if (whipDirection == -1 && nowWhipAngle <= -_maxWhipAngle)
        {
            whipDirection = 1;
        }

        _angle = new Vector2(nowWhipAngle, _angle.y);
    }
}
