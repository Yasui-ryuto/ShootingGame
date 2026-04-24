using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameObject player;

    public static GameManager Incetance { get; private set; }

    [Header("EnemyObject")]
    [SerializeField] private GameObject empty; //空のオブジェクト
    [SerializeField] private GameObject enemyWhip; 
    [SerializeField] private GameObject enemyRotation;
    [SerializeField] private GameObject enemyWave;

    [Header("EnemySetting")]
    [SerializeField] private Vector3 firstPos;

    private GameObject[] enemy = new GameObject[10]; //ステージ上にある敵を入れる

    private bool isWaveStart = true; //ウェーブが始まってるかのフラグ


    private enum Situation
    {
        GameInterval,
        Wave1,
        Wave2,
        Wave3,
        Wave4,
        Wave5,
    }

    [SerializeField] private Situation situation = 0;


    private void Awake()
    {
        Incetance = this;
        player = GameObject.Find("Player").gameObject;

        player.GetComponent<PlayerShotBullet>().enabled = false; //プレイヤーの球の発射を停止

    }
    private void Start()
    {

        //enemyの中身をemptyオブジェクトにする
        for(int i = 0; i < enemy.Length; i++)
        {
            enemy[i] = empty;
        }
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

        player.GetComponent<PlayerShotBullet>().enabled = true; //プレイヤーの球の発射を再開
        situation++;
    }

    private void Wave1()
    {
        if (isWaveStart)
        {
            enemy[0] = Instantiate(enemyWave, firstPos, Quaternion.identity); //敵の生成
            isWaveStart = false;
        }
    }

    private void Wave2()
    {
        //敵の生成
        if (isWaveStart)
        {
            enemy[0] = Instantiate(enemyWave, new Vector3(-2f, 4f, 0f), Quaternion.identity);
            enemy[1] = Instantiate(enemyWhip, new Vector3(2f, 4f, 0f), Quaternion.identity);
            isWaveStart = false;
        }
    }


    public IEnumerator BrokenEnemy(GameObject enemy)
    {
        int enemyCount = 0; //配列内のemptyオブジェクトの数

        for(int i = 0; i < this.enemy.Length; i++)
        {
            if (this.enemy[i] == empty || this.enemy[i] == enemy)
            {
                //配列内のオブジェクトと破壊したいオブジェクトが一緒だった時
                if (this.enemy[i] == enemy)
                {
                    yield return StartCoroutine(BreakEnemy(enemy));
                    this.enemy[i] = empty;
                }
                enemyCount++;
            }
        }

        //敵がいなくなれば次のウェーブに行く
        if(this.enemy.Length == enemyCount)
        {
            situation++;
            isWaveStart = true;
        }

        Destroy(enemy);

    }

    //敵の消滅アニメーション
    private IEnumerator BreakEnemy(GameObject enemy)
    {
        yield return null;
    }
}
