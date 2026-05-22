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
