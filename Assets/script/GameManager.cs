using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    [HideInInspector] public GameObject player;

    [HideInInspector] public static GameManager Incetance { get; private set; }
    public GameObject empty; //空のオブジェクト
    [HideInInspector] public GameObject[] enemy = new GameObject[10]; //ステージ上にある敵を入れる
    [HideInInspector] public GameObject[] HPBars = new GameObject[10]; //HPBarを入れる

    [Header("BGM")]
    public AudioClip startBGM;
    public AudioClip mainBGM;

    [Header("Sound")]
    public AudioClip shoot;
    public AudioClip hit;
    public AudioClip rotation1;
    public AudioClip rotation2;
    public AudioClip bom1;
    public AudioClip bom2;
    public AudioClip bom3;
    public AudioClip bom4;

    [Header("Situation")]
    public Situation situation = 0;

    public enum Situation
    {
        GameInterval,
        Wave1,
        Wave2,
        Wave3,
        Wave4,
        Wave5,
        Wave6,
        GameClear,
        Pause,
        Died,
    }

    private void Awake()
    {
        Application.targetFrameRate = 60;

        Incetance = this;
        player = GameObject.Find("Player").gameObject;
        player.GetComponent<PlayerShotBullet>().enabled = false; //プレイヤーの球の発射を停止

        //enemyとHPBarsの中身をemptyオブジェクトにする
        for (int i = 0; i < enemy.Length; i++)
        {
            enemy[i] = empty;
            HPBars[i] = empty;
        }

        GetComponent<AudioSource>().loop = true;
    }

}
