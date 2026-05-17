using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using static GameManager;

public class WaveController : MonoBehaviour
{
    private GameManager manager;
    private NamePlateController namePlateCon;
    [SerializeField] private Situation situation = 0;

    [Header("EnemyObject")]
    [SerializeField] private GameObject enemyWhip;
    [SerializeField] private GameObject enemyRotation;
    [SerializeField] private GameObject enemyWave;

    [Header("EnemySetting")]
    [SerializeField] private Vector3 firstPos;

    private bool isWaveStart = true; //ウェーブが始まってるかのフラグ

    private void Start()
    {
        manager = GameManager.Incetance;
        namePlateCon = transform.GetComponent<NamePlateController>();
    }
    private void Update()
    {
        switch (situation)
        {
            case Situation.GameInterval:
                GameInterval();
                break;
            case Situation.Wave1:
                Wave1();
                break;
            case Situation.Wave2:
                Wave2();
                break;
            case Situation.Wave3:
                break;
            case Situation.Wave4:
                break;

        }

    }

    private void GameInterval()
    {
        //スペースキーを押して３秒後ウェーブ１開始
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            StartCoroutine(GameStart());
        }
    }

    private IEnumerator GameStart()
    {
        Debug.Log("3");
        yield return new WaitForSeconds(1);
        Debug.Log("2");
        yield return new WaitForSeconds(1);
        Debug.Log("1");
        yield return new WaitForSeconds(1);
        Debug.Log("Start");
        yield return new WaitForSeconds(1);


        situation++;
    }

    private void Wave1()
    {
        //Wave1にに1回だけ実行
        if (isWaveStart)
        {
            StartCoroutine(Wave1Start());
            isWaveStart = false;
        }
    }

    private IEnumerator Wave1Start()
    {
        manager.enemy[0] = Instantiate(enemyWave, firstPos, Quaternion.identity); //敵の生成
        manager.enemy[0].GetComponent<EnemyShotBullet>().enabled = false; //敵の弾の発射を停止

        GetComponent<NamePlateController>().SetbarStart(false);

        yield return StartCoroutine(namePlateCon.StartHPBar()); //HPBarの演出

        player.GetComponent<PlayerShotBullet>().enabled = true; //プレイヤーの弾の発射を再開
        manager.enemy[0].GetComponent<EnemyShotBullet>().enabled = true; //敵の弾の発射を再開
    }

    private void Wave2()
    {
        //敵の生成
        if (isWaveStart)
        {
            StartCoroutine(Wave2Start());
            isWaveStart = false;
        }
    }

    private IEnumerator Wave2Start()
    {
        manager.enemy[0] = Instantiate(enemyWave, new Vector3(-2f, 4f, 0f), Quaternion.identity); //敵の生成
        manager.enemy[0].GetComponent<EnemyShotBullet>().enabled = false; //敵の弾の発射を停止
        manager.enemy[1] = Instantiate(enemyWhip, new Vector3(2f, 4f, 0f), Quaternion.identity); //敵の生成
        manager.enemy[1].GetComponent<EnemyShotBullet>().enabled = false; //敵の弾の発射を停止


        GetComponent<NamePlateController>().SetbarStart(false);

        yield return StartCoroutine(namePlateCon.StartHPBar()); //HPBarの演出

        player.GetComponent<PlayerShotBullet>().enabled = true; //プレイヤーの弾の発射を再開
        manager.enemy[0].GetComponent<EnemyShotBullet>().enabled = true; //敵の弾の発射を再開
        manager.enemy[1].GetComponent<EnemyShotBullet>().enabled = true; //敵の弾の発射を再開

    }

    public IEnumerator BrokenEnemy(GameObject enemy)
    {
        int enemyCount = 0; //配列内のemptyオブジェクトの数

        for (int i = 0; i < manager.enemy.Length; i++)
        {
            if (manager.enemy[i] == manager.empty || manager.enemy[i] == enemy)
            {
                //配列内のオブジェクトと破壊したいオブジェクトが一緒だった時
                if (manager.enemy[i] == enemy)
                {
                    yield return StartCoroutine(BreakEnemy(enemy));
                    manager.enemy[i] = manager.empty;
                    manager.HPBars[i] = manager.empty;
                }
                enemyCount++;
            }
        }

        //敵がいなくなれば次のウェーブに行く
        if (manager.enemy.Length == enemyCount)
        {
            situation++;
            isWaveStart = true;
            GetComponent<NamePlateController>().SetbarStart(false);
        }

        Destroy(enemy);

    }

    //敵の消滅アニメーション
    private IEnumerator BreakEnemy(GameObject enemy)
    {
        yield return null;
    }
}
