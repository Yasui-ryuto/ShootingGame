using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using static GameManager;

public class WaveController : MonoBehaviour
{
    private GameManager manager;
    private NamePlateController namePlateCon;

    [SerializeField] private bool isWaveStart = true; //ウェーブが始まってるかのフラグ
    [SerializeField] private GameObject textPrefab; //「Press Space to Start」のプレハブ
    private GameObject gameStartText; //シーン内にあるtextPrefab
    [SerializeField] private float diedTimeScale = 0.2f; //死亡時演出の時間の速さ

    [Header("EnemyObject")]
    [SerializeField] private GameObject enemyWhip;
    [SerializeField] private GameObject enemyRotation;
    [SerializeField] private GameObject enemyWave;
    [SerializeField] private GameObject enemyLaser;
    [SerializeField] private GameObject enemyStop;

    [Header("EnemyBreakEffect")]
    [SerializeField] private GameObject[] diedEffectPrefab;

    private void Start()
    {
        manager = GameManager.Incetance;
        namePlateCon = transform.GetComponent<NamePlateController>();
        manager.gameOver.SetActive(false);
        gameStartText = manager.empty;
    }

    private void Update()
    {
        if(manager.situation == Situation.Died)
        {

        }
        else if(manager.situation == Situation.GameClear)
        {

        }
        else if (isWaveStart)
        {
            switch (manager.situation)
            {
                case Situation.GameInterval:
                    GameInterval();
                    break;

                case Situation.Wave1:
                    StartCoroutine(Wave1Start());
                    isWaveStart = false;
                    break;

                case Situation.Wave2:
                    StartCoroutine(Wave2Start());
                    isWaveStart = false;
                    break;

                case Situation.Wave3:
                    StartCoroutine(Wave3Start());
                    isWaveStart = false;
                    break;

                case Situation.Wave4:
                    StartCoroutine(Wave4Start());
                    isWaveStart = false;
                    break;

                case Situation.Wave5:
                    StartCoroutine(Wave5Start());
                    isWaveStart = false;
                    break;
            }
        }
        Guide();
    }

    private void Guide()
    {
        //操作ガイドをエスケープで開閉できる
        //プレイヤーが死んでいないとき
        if (Keyboard.current.escapeKey.wasPressedThisFrame && Time.timeScale != diedTimeScale)
        {
            if(manager.situation == Situation.ControllerGuide)
            {
                GetComponent<ButtonController>().CloseGuide();
            }
            else
            {
                GetComponent<ButtonController>().OpenGuide();
            }
        }
    }

    private void GameInterval()
    {
        if(gameStartText == manager.empty)
        {
            gameStartText = Instantiate(textPrefab, GameObject.Find("Canvas").transform);
        }
        //スペースキーを押して３秒後ウェーブ１開始
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            isWaveStart = false;
            Destroy(gameStartText);
            gameStartText = manager.empty;
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

        //コンティニュー時にプレイヤーを再生成する
        if(manager.player == manager.empty)
        {
            manager.player = Instantiate(manager.playerPrefab, new Vector3(0.0f, -4.0f, 0.0f), Quaternion.identity);
            manager.player.GetComponent<PlayerShotBullet>().enabled = false;
        }

        isWaveStart = true;
        manager.situation++;
    }

    private IEnumerator Wave1Start()
    {
        manager.enemy[0] = Instantiate(enemyWave, new Vector3(0.0f, 4.0f, 0.0f), Quaternion.identity); //敵の生成
        manager.enemy[0].GetComponent<EnemyShotBullet>().enabled = false; //敵の弾の発射を停止

        GetComponent<NamePlateController>().SetbarStart(false); //barStart(HPBar演出フラグ)をfalseにする

        yield return StartCoroutine(namePlateCon.StartHPBar()); //HPBarの演出

        manager.player.GetComponent<PlayerShotBullet>().enabled = true; //プレイヤーの弾の発射を再開
        manager.enemy[0].GetComponent<EnemyShotBullet>().enabled = true; //敵の弾の発射を再開
    }

    private IEnumerator Wave2Start()
    {
        manager.enemy[0] = Instantiate(enemyWave, new Vector3(-2f, 4f, 0f), Quaternion.identity); //敵の生成
        manager.enemy[0].GetComponent<EnemyShotBullet>().enabled = false; //敵の弾の発射を停止
        manager.enemy[1] = Instantiate(enemyWhip, new Vector3(2f, 4f, 0f), Quaternion.identity); //敵の生成
        manager.enemy[1].GetComponent<EnemyShotBullet>().enabled = false; //敵の弾の発射を停止

        GetComponent<NamePlateController>().SetbarStart(false); //barStart(HPBar演出フラグ)をfalseにする

        yield return StartCoroutine(namePlateCon.StartHPBar()); //HPBarの演出

        manager.player.GetComponent<PlayerShotBullet>().enabled = true; //プレイヤーの弾の発射を再開
        manager.enemy[0].GetComponent<EnemyShotBullet>().enabled = true; //敵の弾の発射を再開
        manager.enemy[1].GetComponent<EnemyShotBullet>().enabled = true; //敵の弾の発射を再開

    }

    private IEnumerator Wave3Start()
    {
        manager.enemy[0] = Instantiate(enemyLaser, new Vector3(-2f, 4f, 0f), Quaternion.identity); //敵の生成
        manager.enemy[0].GetComponent<LaserAttacker>().enabled = false; //敵の弾の発射を停止
        manager.enemy[1] = Instantiate(enemyLaser, new Vector3(2f, 4f, 0f), Quaternion.identity); //敵の生成
        manager.enemy[1].GetComponent<LaserAttacker>().enabled = false; //敵の弾の発射を停止

        GetComponent<NamePlateController>().SetbarStart(false);

        yield return StartCoroutine(namePlateCon.StartHPBar()); //HPBarの演出

        manager.player.GetComponent<PlayerShotBullet>().enabled = true; //プレイヤーの弾の発射を再開
        manager.enemy[0].GetComponent<LaserAttacker>().enabled = true; //敵の弾の発射を再開
        manager.enemy[1].GetComponent<LaserAttacker>().enabled = true; //敵の弾の発射を再開
    }

    private IEnumerator Wave4Start()
    {
        manager.enemy[0] = Instantiate(enemyStop, new Vector3(-2f, 4f, 0f), Quaternion.identity); //敵の生成
        manager.enemy[0].GetComponent<StopTemporarilyAttacker>().enabled = false; //敵の弾の発射を停止
        manager.enemy[1] = Instantiate(enemyLaser, new Vector3(2f, 4f, 0f), Quaternion.identity); //敵の生成
        manager.enemy[1].GetComponent<LaserAttacker>().enabled = false; //敵の弾の発射を停止

        GetComponent<NamePlateController>().SetbarStart(false);

        yield return StartCoroutine(namePlateCon.StartHPBar()); //HPBarの演出

        manager.player.GetComponent<PlayerShotBullet>().enabled = true; //プレイヤーの弾の発射を再開
        manager.enemy[0].GetComponent<StopTemporarilyAttacker>().enabled = true; //敵の弾の発射を再開
        manager.enemy[1].GetComponent<LaserAttacker>().enabled = true; //敵の弾の発射を再開
    }

    private IEnumerator Wave5Start()
    {
        manager.enemy[0] = Instantiate(enemyLaser, new Vector3(-3f, 4f, 0f), Quaternion.identity); //敵の生成
        manager.enemy[0].GetComponent<LaserAttacker>().enabled = false; //敵の弾の発射を停止
        manager.enemy[1] = Instantiate(enemyStop, new Vector3(4f, 0f, 0f), Quaternion.identity); //敵の生成
        manager.enemy[1].GetComponent<StopTemporarilyAttacker>().enabled = false; //敵の弾の発射を停止
        manager.enemy[2] = Instantiate(enemyWhip, new Vector3(4f, 4f, 0f), Quaternion.identity); //敵の生成
        manager.enemy[2].GetComponent<EnemyShotBullet>().enabled = false; //敵の弾の発射を停止

        GetComponent<NamePlateController>().SetbarStart(false);

        yield return StartCoroutine(namePlateCon.StartHPBar()); //HPBarの演出

        manager.player.GetComponent<PlayerShotBullet>().enabled = true; //プレイヤーの弾の発射を再開
        manager.enemy[0].GetComponent<LaserAttacker>().enabled = true; //敵の弾の発射を再開
        manager.enemy[1].GetComponent<StopTemporarilyAttacker>().enabled = true; //敵の弾の発射を再開
        manager.enemy[2].GetComponent<EnemyShotBullet>().enabled = true; //敵の弾の発射を再開
    }

    public IEnumerator BreakEnemy(GameObject enemy)
    {
        int enemyCount = 0; //配列内のemptyオブジェクトの数

        for (int i = 0; i < manager.enemy.Length; i++)
        {
            if (manager.enemy[i] == manager.empty || manager.enemy[i] == enemy)
            {
                //配列内のオブジェクトと破壊したいオブジェクトが一緒だった時
                if (manager.enemy[i] == enemy)
                {
                    //弾の停止
                    if (enemy.GetComponent<EnemyShotBullet>())
                    {
                        enemy.GetComponent<EnemyShotBullet>().enabled = false;
                    }
                    else if (enemy.GetComponent<LaserAttacker>())
                    {
                        enemy.GetComponent<LaserAttacker>().enabled = false;
                    }

                    yield return StartCoroutine(DiedEffect(enemy, diedEffectPrefab)); //アニメーションが終わるまで待つ

                    manager.enemy[i] = manager.empty;
                }
                enemyCount++;
            }
        }

        Coroutine coroutine = null;

        //敵がいなくなれば次のウェーブに行く
        if (manager.enemy.Length == enemyCount && coroutine == null)
        {
            yield return coroutine = StartCoroutine(NextWave());
        }

        Destroy(enemy);
    }

    private IEnumerator NextWave()
    {
        manager.player.GetComponent<PlayerShotBullet>().enabled = false; //プレイヤーの弾の発射を停止

        yield return new WaitForSeconds(2);

        manager.situation++;
        isWaveStart = true;
        //HPバーの初期化
        for (int i = 0; i < manager.HPBars.Length; i++)
        {
            Destroy(manager.HPBars[i]);
            manager.HPBars[i] = manager.empty;
        }
        GetComponent<NamePlateController>().SetbarStart(false);
    }

    /// <summary>
    /// 消滅エフェクト
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="effects"></param>
    /// <returns></returns>
    public IEnumerator DiedEffect(GameObject obj, GameObject[] effects)
    {
        ParticleSystem[] effect = new ParticleSystem[effects.Length];
        for (int i = 0; i < effects.Length; i++)
        {
            effect[i] = Instantiate(effects[i], obj.transform.position, Quaternion.identity).GetComponent<ParticleSystem>();
            effect[i].Play();
        }

        if (obj.CompareTag("Player"))
        {
            foreach(GameObject enemy in manager.enemy)
            {
                if (enemy.GetComponent<EnemyShotBullet>())
                {
                    enemy.GetComponent<EnemyShotBullet>().enabled = false;
                }
                else if (enemy.GetComponent<LaserAttacker>())
                {
                    enemy.GetComponent <LaserAttacker>().enabled = false;
                }
            }

            Time.timeScale = diedTimeScale;
        }

        obj.transform.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);

        yield return new WaitWhile(() => MaxTimeEffect(effect).IsAlive(true));

        if (obj.CompareTag("Player"))
        {
            Time.timeScale = 1.0f;
            manager.situation = Situation.Died;
            for(int i = 0; i < manager.enemy.Length; i++)
            {
                if (manager.enemy[i] != manager.empty)
                {
                    Destroy(manager.enemy[i]);
                    Destroy(manager.HPBars[i]);
                    manager.enemy[i] = manager.empty;
                    manager.HPBars[i] = manager.empty;
                }
            }
            isWaveStart = true;
            manager.gameOver.SetActive(true);
            manager.player = manager.empty;
        }

        Destroy(obj);
    }

    /// <summary>
    /// 配列内の最長エフェクト探す
    /// </summary>
    /// <param name="effects"></param>
    /// <returns></returns>
    public ParticleSystem MaxTimeEffect(ParticleSystem[] effects)
    {
        ParticleSystem maxEffect = null;
        foreach(var effect in effects)
        {
            if(maxEffect == null)
            {
                maxEffect = effect;
            }
            else if(maxEffect.main.duration > effect.main.duration)
            {
                maxEffect = effect;
            }
        }

        return maxEffect;
    }
}
