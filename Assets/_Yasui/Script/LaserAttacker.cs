using System;
using System.Collections;
using UnityEngine;

public class LaserAttacker : MonoBehaviour
{
    [SerializeField] private GameObject laserEffect;

    [Header("この変数をオンでレーザー発射")]
    public bool isLaserShoot = true;
    private bool isLaserEnd = true; //レーザーが終わったかのフラグ


    private void Update()
    {
        if (isLaserShoot && isLaserEnd)
        {
            Instantiate(laserEffect, transform.position, Quaternion.identity, transform); //オブジェクトの生成
            StartCoroutine(DestroyObj()); //生成したオブジェクトを消すコルーチン
            isLaserShoot = false;
        }
    }


    private IEnumerator DestroyObj()
    {
        isLaserEnd = false;

        yield return new WaitForSeconds(6f);

        Destroy(transform.GetChild(0).gameObject);
        isLaserEnd = true;
    }
}
