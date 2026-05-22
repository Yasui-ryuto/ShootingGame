using System.Collections;
using UnityEngine;
using static GameManager;

public class LaserAttacker : MonoBehaviour
{
    [SerializeField] private GameObject laserEffect;

    [Header("この変数をオンでレーザー発射")]
    public bool isLaserShoot = true;


    private void Update()
    {
        if (isLaserShoot)
        {
            Instantiate(laserEffect, transform.position, Quaternion.identity, transform); //オブジェクトの生成
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x) * Mathf.Rad2Deg - 90);
            StartCoroutine(DestroyObj()); //生成したオブジェクトを消すコルーチン
        }
    }


    private IEnumerator DestroyObj()
    {
        isLaserShoot = false;

        yield return new WaitForSeconds(6f);

        Destroy(transform.GetChild(0).gameObject);
        isLaserShoot = true;
    }
}
