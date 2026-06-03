using System.Collections;
using UnityEngine;
using static GameManager;

public class LaserPathEffect : MonoBehaviour
{
    private Vector3 playerDirect;
    [HideInInspector] public Vector3 endPosition; //エフェクト終了位置
    
    [SerializeField] private float effectLength = 0.3f; //エフェクトの長さ
    private Vector3 velocity = Vector3.zero; //SmoothDampの第3引数（現在の速度）
    [SerializeField] private bool isLaser = true; //レーザーの発射フラグ
    [SerializeField] private float laserShootTime = 3f; //このオブジェクトが生成されてからレーザーが発射されるまでの時間

    [SerializeField] private GameObject LaserEffect;

    void Start()
    {
        playerDirect = (Incetance.player.transform.position - transform.position) * effectLength; // プレイヤーの方向を取得
        endPosition = Incetance.player.transform.position + playerDirect; //エフェクト終了位置

        //float angle = Mathf.Atan2(playerDirect.y, playerDirect.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);
    }

    // Update is called once per frame
    void Update()
    {
        //エフェクト終了位置に近づいたら
        if (Vector3.Distance(transform.position, endPosition) > 1f)
        {
            transform.position = Vector3.SmoothDamp(transform.position, endPosition, ref velocity, 0.02f); //オブジェクトを終了位置に近づける
        }
        else if(isLaser)
        {
            StartCoroutine(LaserShoot());
            isLaser = false; 
        }
    }

    private IEnumerator LaserShoot()
    {
        yield return new WaitForSeconds(laserShootTime);

        Instantiate(LaserEffect, transform.parent.position, Quaternion.Euler(0.0f, 0.0f, Mathf.Atan2(playerDirect.y, playerDirect.x) * Mathf.Rad2Deg), transform);

        /*Mathf.Atan2(playerDirect.y, playerDirect.x) * Mathf.Rad2Deg
         * Atan - ベクトルから角度（ラジアン）に変更
         * Atan - 0-180
         * Atan2 - 0-360
         * 
         * Mathf.Rad2Deg - (Radian to Degree)ラジアンから度に変換
         * Mathf.Deg2Rad - (Degree to Radian)度からラジアンに変換
         */
    }
}
