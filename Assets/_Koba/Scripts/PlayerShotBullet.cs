using UnityEngine;

public class PlayerShotBullet : BaseShotBullet
{
    protected override void Start()
    {
        _shotDirection = Vector2.up;
    }
}
