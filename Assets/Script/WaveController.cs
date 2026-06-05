using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using static GameManager;
using UnityEngine.UI;


public class WaveController : MonoBehaviour
{
    private GameManager manager;
    private NamePlateController namePlateCon;

    [SerializeField] private bool isWaveStart = true; //ƒEƒF[ƒu‚ªn‚Ü‚Á‚Ä‚é‚©‚Ìƒtƒ‰ƒO
    [SerializeField] private GameObject textPrefab; //uPress Space to Startv‚ÌƒvƒŒƒnƒu
    private GameObject gameStartText; //ƒV[ƒ““à‚É‚ ‚étextPrefab
    [SerializeField] private float diedTimeScale = 0.2f; //€–S‰‰o‚ÌŠÔ‚Ì‘¬‚³

    [Header("EnemyObject")]
    [SerializeField] private GameObject enemyWhip;
    [SerializeField] private GameObject enemyRotation;
    [SerializeField] private GameObject enemyWave;
    [SerializeField] private GameObject enemyLaser;
    [SerializeField] private GameObject enemyStop;

    [Header("EnemyBreakEffect")]
    [SerializeField] private GameObject[] diedEffectPrefab;

    [Header("Button")]
    [SerializeField] private GameObject pauseButton;

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

                case Situation.Wave6:
                    StartCoroutine(Wave6Start());
                    isWaveStart = false;
                    break;
            }
        }
        Pause();
    }

    private void Pause()
    {
        //ˆê’â~iƒ|[ƒYj‚ğƒGƒXƒP[ƒv‚Å‚Å‚«‚é
        //ƒvƒŒƒCƒ„[‚ª€‚ñ‚Å‚¢‚È‚¢‚Æ‚«
        if (Keyboard.current.escapeKey.wasPressedThisFrame && Time.timeScale != diedTimeScale && manager.situation != Situation.GameInterval && manager.situation != Situation.Died)
        {
            if(manager.situation == Situation.Pause)
            {
                GetComponent<ButtonController>().PauseFinish();
            }
            else
            {
                GetComponent<ButtonController>().PauseStart();
            }
        }
    }

    private void GameInterval()
    {
        if(gameStartText == manager.empty)
        {
            gameStartText = Instantiate(textPrefab, GameObject.Find("Canvas").transform);
        }
        //ƒXƒy[ƒXƒL[‚ğ‰Ÿ‚µ‚Ä‚R•bŒãƒEƒF[ƒu‚PŠJn
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

        //ƒRƒ“ƒeƒBƒjƒ…[‚ÉƒvƒŒƒCƒ„[‚ğÄ¶¬‚·‚é
        if(manager.player == manager.empty)
        {
            manager.player = Instantiate(manager.playerPrefab, new Vector3(0.0f, -4.0f, 0.0f), Quaternion.identity);
            manager.player.GetComponent<PlayerShotBullet>().enabled = false;
        }

        pauseButton.GetComponent<Button>().interactable = true;
        isWaveStart = true;
        manager.situation++;
    }

    private IEnumerator Wave1Start()
    {
        manager.enemy[0] = Instantiate(enemyWave, new Vector3(0.0f, 4.0f, 0.0f), Quaternion.identity); //“G‚Ì¶¬
        manager.enemy[0].GetComponent<EnemyShotBullet>().enabled = false; //“G‚Ì’e‚Ì”­Ë‚ğ’â~

        GetComponent<NamePlateController>().SetbarStart(false); //barStart(HPBar‰‰oƒtƒ‰ƒO)‚ğfalse‚É‚·‚é

        yield return StartCoroutine(namePlateCon.StartHPBar()); //HPBar‚Ì‰‰o

        manager.player.GetComponent<PlayerShotBullet>().enabled = true; //ƒvƒŒƒCƒ„[‚Ì’e‚Ì”­Ë‚ğÄŠJ
        manager.enemy[0].GetComponent<EnemyShotBullet>().enabled = true; //“G‚Ì’e‚Ì”­Ë‚ğÄŠJ
    }

    private IEnumerator Wave2Start()
    {
        manager.enemy[0] = Instantiate(enemyWave, new Vector3(-2f, 4f, 0f), Quaternion.identity); //“G‚Ì¶¬
        manager.enemy[0].GetComponent<EnemyShotBullet>().enabled = false; //“G‚Ì’e‚Ì”­Ë‚ğ’â~
        manager.enemy[1] = Instantiate(enemyWhip, new Vector3(2f, 4f, 0f), Quaternion.identity); //“G‚Ì¶¬
        manager.enemy[1].GetComponent<EnemyShotBullet>().enabled = false; //“G‚Ì’e‚Ì”­Ë‚ğ’â~

        GetComponent<NamePlateController>().SetbarStart(false); //barStart(HPBar‰‰oƒtƒ‰ƒO)‚ğfalse‚É‚·‚é

        yield return StartCoroutine(namePlateCon.StartHPBar()); //HPBar‚Ì‰‰o

        manager.player.GetComponent<PlayerShotBullet>().enabled = true; //ƒvƒŒƒCƒ„[‚Ì’e‚Ì”­Ë‚ğÄŠJ
        manager.enemy[0].GetComponent<EnemyShotBullet>().enabled = true; //“G‚Ì’e‚Ì”­Ë‚ğÄŠJ
        manager.enemy[1].GetComponent<EnemyShotBullet>().enabled = true; //“G‚Ì’e‚Ì”­Ë‚ğÄŠJ

    }

    private IEnumerator Wave3Start()
    {
        manager.enemy[0] = Instantiate(enemyLaser, new Vector3(-2f, 4f, 0f), Quaternion.identity); //“G‚Ì¶¬
        manager.enemy[0].GetComponent<LaserAttacker>().enabled = false; //“G‚Ì’e‚Ì”­Ë‚ğ’â~
        manager.enemy[1] = Instantiate(enemyLaser, new Vector3(2f, 4f, 0f), Quaternion.identity); //“G‚Ì¶¬
        manager.enemy[1].GetComponent<LaserAttacker>().enabled = false; //“G‚Ì’e‚Ì”­Ë‚ğ’â~

        GetComponent<NamePlateController>().SetbarStart(false);

        yield return StartCoroutine(namePlateCon.StartHPBar()); //HPBar‚Ì‰‰o

        manager.player.GetComponent<PlayerShotBullet>().enabled = true; //ƒvƒŒƒCƒ„[‚Ì’e‚Ì”­Ë‚ğÄŠJ
        manager.enemy[0].GetComponent<LaserAttacker>().enabled = true; //“G‚Ì’e‚Ì”­Ë‚ğÄŠJ
        manager.enemy[1].GetComponent<LaserAttacker>().enabled = true; //“G‚Ì’e‚Ì”­Ë‚ğÄŠJ
    }

    private IEnumerator Wave4Start()
    {
        manager.enemy[0] = Instantiate(enemyStop, new Vector3(-2f, 4f, 0f), Quaternion.identity); //“G‚Ì¶¬
        manager.enemy[0].GetComponent<StopTemporarilyAttacker>().enabled = false; //“G‚Ì’e‚Ì”­Ë‚ğ’â~
        manager.enemy[1] = Instantiate(enemyLaser, new Vector3(2f, 4f, 0f), Quaternion.identity); //“G‚Ì¶¬
        manager.enemy[1].GetComponent<LaserAttacker>().enabled = false; //“G‚Ì’e‚Ì”­Ë‚ğ’â~

        GetComponent<NamePlateController>().SetbarStart(false);

        yield return StartCoroutine(namePlateCon.StartHPBar()); //HPBar‚Ì‰‰o

        manager.player.GetComponent<PlayerShotBullet>().enabled = true; //ƒvƒŒƒCƒ„[‚Ì’e‚Ì”­Ë‚ğÄŠJ
        manager.enemy[0].GetComponent<StopTemporarilyAttacker>().enabled = true; //“G‚Ì’e‚Ì”­Ë‚ğÄŠJ
        manager.enemy[1].GetComponent<LaserAttacker>().enabled = true; //“G‚Ì’e‚Ì”­Ë‚ğÄŠJ
    }

    private IEnumerator Wave5Start()
    {
        manager.enemy[0] = Instantiate(enemyLaser, new Vector3(-3f, 4f, 0f), Quaternion.identity); //“G‚Ì¶¬
        manager.enemy[0].GetComponent<LaserAttacker>().enabled = false; //“G‚Ì’e‚Ì”­Ë‚ğ’â~
        manager.enemy[1] = Instantiate(enemyStop, new Vector3(4f, 0f, 0f), Quaternion.identity); //“G‚Ì¶¬
        manager.enemy[1].GetComponent<StopTemporarilyAttacker>().enabled = false; //“G‚Ì’e‚Ì”­Ë‚ğ’â~
        manager.enemy[2] = Instantiate(enemyWhip, new Vector3(4f, 4f, 0f), Quaternion.identity); //“G‚Ì¶¬
        manager.enemy[2].GetComponent<EnemyShotBullet>().enabled = false; //“G‚Ì’e‚Ì”­Ë‚ğ’â~

        GetComponent<NamePlateController>().SetbarStart(false);

        yield return StartCoroutine(namePlateCon.StartHPBar()); //HPBar‚Ì‰‰o

        manager.player.GetComponent<PlayerShotBullet>().enabled = true; //ƒvƒŒƒCƒ„[‚Ì’e‚Ì”­Ë‚ğÄŠJ
        manager.enemy[0].GetComponent<LaserAttacker>().enabled = true; //“G‚Ì’e‚Ì”­Ë‚ğÄŠJ
        manager.enemy[1].GetComponent<StopTemporarilyAttacker>().enabled = true; //“G‚Ì’e‚Ì”­Ë‚ğÄŠJ
        manager.enemy[2].GetComponent<EnemyShotBullet>().enabled = true; //“G‚Ì’e‚Ì”­Ë‚ğÄŠJ
    }

    private IEnumerator Wave6Start()
    {
        manager.enemy[0] = Instantiate(enemyLaser, new Vector3(-6f, 4f, 0f), Quaternion.identity); //“G‚Ì¶¬
        manager.enemy[0].GetComponent<LaserAttacker>().enabled = false; //“G‚Ì’e‚Ì”­Ë‚ğ’â~
        manager.enemy[1] = Instantiate(enemyStop, new Vector3(6f, 4f, 0f), Quaternion.identity); //“G‚Ì¶¬
        manager.enemy[1].GetComponent<StopTemporarilyAttacker>().enabled = false; //“G‚Ì’e‚Ì”­Ë‚ğ’â~
        manager.enemy[2] = Instantiate(enemyWhip, new Vector3(4f, 4f, 0f), Quaternion.identity); //“G‚Ì¶¬
        manager.enemy[2].GetComponent<EnemyShotBullet>().enabled = false; //“G‚Ì’e‚Ì”­Ë‚ğ’â~
        manager.enemy[3] = Instantiate(enemyWhip, new Vector3(-4f, 4f, 0f), Quaternion.identity); //“G‚Ì¶¬
        manager.enemy[3].GetComponent<EnemyShotBullet>().enabled = false; //“G‚Ì’e‚Ì”­Ë‚ğ’â~

        GetComponent<NamePlateController>().SetbarStart(false);

        yield return StartCoroutine(namePlateCon.StartHPBar()); //HPBar‚Ì‰‰o

        manager.player.GetComponent<PlayerShotBullet>().enabled = true; //ƒvƒŒƒCƒ„[‚Ì’e‚Ì”­Ë‚ğÄŠJ
        manager.enemy[0].GetComponent<LaserAttacker>().enabled = true; //“G‚Ì’e‚Ì”­Ë‚ğÄŠJ
        manager.enemy[1].GetComponent<StopTemporarilyAttacker>().enabled = true; //“G‚Ì’e‚Ì”­Ë‚ğÄŠJ
        manager.enemy[2].GetComponent<EnemyShotBullet>().enabled = true; //“G‚Ì’e‚Ì”­Ë‚ğÄŠJ
        manager.enemy[3].GetComponent<EnemyShotBullet>().enabled = true; //“G‚Ì’e‚Ì”­Ë‚ğÄŠJ
    }

    public IEnumerator BreakEnemy(GameObject enemy)
    {
        int enemyCount = 0; //”z—ñ“à‚ÌemptyƒIƒuƒWƒFƒNƒg‚Ì”

        for (int i = 0; i < manager.enemy.Length; i++)
        {
            if (manager.enemy[i] == manager.empty || manager.enemy[i] == enemy)
            {
                //”z—ñ“à‚ÌƒIƒuƒWƒFƒNƒg‚Æ”j‰ó‚µ‚½‚¢ƒIƒuƒWƒFƒNƒg‚ªˆê‚¾‚Á‚½
                if (manager.enemy[i] == enemy)
                {
                    //’e‚Ì’â~
                    if (enemy.GetComponent<EnemyShotBullet>())
                    {
                        enemy.GetComponent<EnemyShotBullet>().enabled = false;
                    }
                    else if (enemy.GetComponent<LaserAttacker>())
                    {
                        enemy.GetComponent<LaserAttacker>().enabled = false;
                    }

                    yield return StartCoroutine(DiedEffect(enemy, diedEffectPrefab)); //ƒAƒjƒ[ƒVƒ‡ƒ“‚ªI‚í‚é‚Ü‚Å‘Ò‚Â

                    manager.enemy[i] = manager.empty;
                }
                enemyCount++;
            }
        }

        Coroutine coroutine = null;

        //“G‚ª‚¢‚È‚­‚È‚ê‚ÎŸ‚ÌƒEƒF[ƒu‚És‚­
        if (manager.enemy.Length == enemyCount && coroutine == null)
        {
            yield return coroutine = StartCoroutine(NextWave());
        }

        Destroy(enemy);
    }

    private IEnumerator NextWave()
    {
        manager.player.GetComponent<PlayerShotBullet>().enabled = false; //ƒvƒŒƒCƒ„[‚Ì’e‚Ì”­Ë‚ğ’â~

        yield return new WaitForSeconds(2);

        manager.situation++;
        isWaveStart = true;
        //HPƒo[‚Ì‰Šú‰»
        for (int i = 0; i < manager.HPBars.Length; i++)
        {
            Destroy(manager.HPBars[i]);
            manager.HPBars[i] = manager.empty;
        }
        GetComponent<NamePlateController>().SetbarStart(false);
    }

    /// <summary>
    /// Á–ÅƒGƒtƒFƒNƒg
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
                if (enemy != null)
                {
                    if (enemy.GetComponent<EnemyShotBullet>())
                    {
                        enemy.GetComponent<EnemyShotBullet>().enabled = false;
                    }
                    else if (enemy.GetComponent<LaserAttacker>())
                    {
                        enemy.GetComponent<LaserAttacker>().enabled = false;
                    }
                }
            }

            pauseButton.GetComponent<Button>().interactable = false;
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
        foreach(var eff in effect)
        {
            Destroy(eff.gameObject);
        }
        Destroy(obj);
    }

    /// <summary>
    /// ”z—ñ“à‚ÌÅ’·ƒGƒtƒFƒNƒg’T‚·
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
