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

    [SerializeField] private bool _useSin = false;

    protected override void Start()
    {
        base.Start();

        if (_useSin)
        {
            SetWhipAngle_Sin();
        }
        else
        {
            SetWhipAngle();
        }
    }

    /// <summary>
    /// だるい処理だけど、最大角度が自由に変えれるところは便利
    /// </summary>
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

    /// <summary>
    /// どうやったら最大角度が大きくなるかわからない
    /// そのままかけ算すると、まっすぐになればなるほど弾数が少なくなる←簡単になる...
    /// </summary>
    private void SetWhipAngle_Sin()
    {
        nowWhipAngle += _increaseWhipAngle;
        float x = Mathf.Sin(nowWhipAngle);
        _angle = new Vector2(x, _angle.y);
    }
}
