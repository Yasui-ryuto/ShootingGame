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
    [SerializeField] private GameObject enemyLaser;
    [SerializeField] private GameObject enemyStop;

    [Header("EnemyBreakEffect")]
    [SerializeField] private GameObject[] diedEffectPrefab;

    [Header("EnemySetting")]
    [SerializeField] private Vector3 firstPos;

    private bool isWaveStart = true; //ƒEƒF[ƒu‚ªn‚Ü‚Á‚Ä‚é‚©‚Ìƒtƒ‰ƒO

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
                Wave3();
                break;
            case Situation.Wave4:
                Wave4();
                break;
            case Situation.Wave5:
                Wave5();
                break;

        }
    }

    private void GameInterval()
    {
        //ƒXƒy[ƒXƒL[‚ğ‰Ÿ‚µ‚Ä‚R•bŒãƒEƒF[ƒu‚PŠJn
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
        //Wave1‚É‚É1‰ñ‚¾‚¯Às
        if (isWaveStart)
        {
            StartCoroutine(Wave1Start());
            isWaveStart = false;
        }
    }

    private IEnumerator Wave1Start()
    {
        manager.enemy[0] = Instantiate(enemyWave, firstPos, Quaternion.identity); //“G‚Ì¶¬
        manager.enemy[0].GetComponent<EnemyShotBullet>().enabled = false; //“G‚Ì’e‚Ì”­Ë‚ğ’â~

        GetComponent<NamePlateController>().SetbarStart(false); //barStart(HPBar‰‰oƒtƒ‰ƒO)‚ğfalse‚É‚·‚é

        yield return StartCoroutine(namePlateCon.StartHPBar()); //HPBar‚Ì‰‰o

        player.GetComponent<PlayerShotBullet>().enabled = true; //ƒvƒŒƒCƒ„[‚Ì’e‚Ì”­Ë‚ğÄŠJ
        manager.enemy[0].GetComponent<EnemyShotBullet>().enabled = true; //“G‚Ì’e‚Ì”­Ë‚ğÄŠJ
    }

    private void Wave2()
    {
        //“G‚Ì¶¬
        if (isWaveStart)
        {
            StartCoroutine(Wave2Start());
            isWaveStart = false;
        }
    }

    private IEnumerator Wave2Start()
    {
        manager.enemy[0] = Instantiate(enemyWave, new Vector3(-2f, 4f, 0f), Quaternion.identity); //“G‚Ì¶¬
        manager.enemy[0].GetComponent<EnemyShotBullet>().enabled = false; //“G‚Ì’e‚Ì”­Ë‚ğ’â~
        manager.enemy[1] = Instantiate(enemyWhip, new Vector3(2f, 4f, 0f), Quaternion.identity); //“G‚Ì¶¬
        manager.enemy[1].GetComponent<EnemyShotBullet>().enabled = false; //“G‚Ì’e‚Ì”­Ë‚ğ’â~

        GetComponent<NamePlateController>().SetbarStart(false); //barStart(HPBar‰‰oƒtƒ‰ƒO)‚ğfalse‚É‚·‚é

        yield return StartCoroutine(namePlateCon.StartHPBar()); //HPBar‚Ì‰‰o

        player.GetComponent<PlayerShotBullet>().enabled = true; //ƒvƒŒƒCƒ„[‚Ì’e‚Ì”­Ë‚ğÄŠJ
        manager.enemy[0].GetComponent<EnemyShotBullet>().enabled = true; //“G‚Ì’e‚Ì”­Ë‚ğÄŠJ
        manager.enemy[1].GetComponent<EnemyShotBullet>().enabled = true; //“G‚Ì’e‚Ì”­Ë‚ğÄŠJ

    }

    private void Wave3()
    {
        //Wave3‚É‚É3‰ñ‚¾‚¯Às
        if (isWaveStart)
        {
            StartCoroutine(Wave3Start());
            isWaveStart = false;
        }
    }

    private IEnumerator Wave3Start()
    {
        manager.enemy[0] = Instantiate(enemyLaser, new Vector3(-2f, 4f, 0f), Quaternion.identity); //“G‚Ì¶¬
        manager.enemy[0].GetComponent<LaserAttacker>().enabled = false; //“G‚Ì’e‚Ì”­Ë‚ğ’â~
        manager.enemy[1] = Instantiate(enemyLaser, new Vector3(2f, 4f, 0f), Quaternion.identity); //“G‚Ì¶¬
        manager.enemy[1].GetComponent<LaserAttacker>().enabled = false; //“G‚Ì’e‚Ì”­Ë‚ğ’â~

        GetComponent<NamePlateController>().SetbarStart(false);

        yield return StartCoroutine(namePlateCon.StartHPBar()); //HPBar‚Ì‰‰o

        player.GetComponent<PlayerShotBullet>().enabled = true; //ƒvƒŒƒCƒ„[‚Ì’e‚Ì”­Ë‚ğÄŠJ
        manager.enemy[0].GetComponent<LaserAttacker>().enabled = true; //“G‚Ì’e‚Ì”­Ë‚ğÄŠJ
        manager.enemy[1].GetComponent<LaserAttacker>().enabled = true; //“G‚Ì’e‚Ì”­Ë‚ğÄŠJ
    }

    private void Wave4()
    {
        //Wave4‚É‚É1‰ñ‚¾‚¯Às
        if (isWaveStart)
        {
            StartCoroutine(Wave4Start());
            isWaveStart = false;
        }
    }

    private IEnumerator Wave4Start()
    {
        manager.enemy[0] = Instantiate(enemyStop, new Vector3(-2f, 4f, 0f), Quaternion.identity); //“G‚Ì¶¬
        manager.enemy[0].GetComponent<StopTemporarilyAttacker>().enabled = false; //“G‚Ì’e‚Ì”­Ë‚ğ’â~
        manager.enemy[1] = Instantiate(enemyLaser, new Vector3(2f, 4f, 0f), Quaternion.identity); //“G‚Ì¶¬
        manager.enemy[1].GetComponent<LaserAttacker>().enabled = false; //“G‚Ì’e‚Ì”­Ë‚ğ’â~

        GetComponent<NamePlateController>().SetbarStart(false);

        yield return StartCoroutine(namePlateCon.StartHPBar()); //HPBar‚Ì‰‰o

        player.GetComponent<PlayerShotBullet>().enabled = true; //ƒvƒŒƒCƒ„[‚Ì’e‚Ì”­Ë‚ğÄŠJ
        manager.enemy[0].GetComponent<StopTemporarilyAttacker>().enabled = true; //“G‚Ì’e‚Ì”­Ë‚ğÄŠJ
        manager.enemy[1].GetComponent<LaserAttacker>().enabled = true; //“G‚Ì’e‚Ì”­Ë‚ğÄŠJ
    }

    private void Wave5()
    {
        //Wave5‚É‚É1‰ñ‚¾‚¯Às
        if (isWaveStart)
        {
            StartCoroutine(Wave5Start());
            isWaveStart = false;
        }
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

        player.GetComponent<PlayerShotBullet>().enabled = true; //ƒvƒŒƒCƒ„[‚Ì’e‚Ì”­Ë‚ğÄŠJ
        manager.enemy[0].GetComponent<LaserAttacker>().enabled = true; //“G‚Ì’e‚Ì”­Ë‚ğÄŠJ
        manager.enemy[1].GetComponent<StopTemporarilyAttacker>().enabled = true; //“G‚Ì’e‚Ì”­Ë‚ğÄŠJ
        manager.enemy[2].GetComponent<EnemyShotBullet>().enabled = true; //“G‚Ì’e‚Ì”­Ë‚ğÄŠJ
    }

    public IEnumerator BrokenEnemy(GameObject enemy)
    {
        int enemyCount = 0; //”z—ñ“à‚ÌemptyƒIƒuƒWƒFƒNƒg‚Ì”

        for (int i = 0; i < manager.enemy.Length; i++)
        {
            if (manager.enemy[i] == manager.empty || manager.enemy[i] == enemy)
            {
                //”z—ñ“à‚ÌƒIƒuƒWƒFƒNƒg‚Æ”j‰ó‚µ‚½‚¢ƒIƒuƒWƒFƒNƒg‚ªˆê‚¾‚Á‚½
                if (manager.enemy[i] == enemy)
                {
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
        player.GetComponent<PlayerShotBullet>().enabled = false; //ƒvƒŒƒCƒ„[‚Ì’e‚Ì”­Ë‚ğ’â~

        yield return new WaitForSeconds(2);

        situation++;
        isWaveStart = true;
        for (int i = 0; i < manager.HPBars.Length; i++)
        {
            Destroy(manager.HPBars[i]);
            manager.HPBars[i] = manager.empty;
        }
        GetComponent<NamePlateController>().SetbarStart(false);
    }

    //“G‚ÌÁ–ÅƒGƒtƒFƒNƒg
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
        }

        obj.transform.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);

        yield return new WaitWhile(() => MaxTimeEffect(effect).IsAlive(true));

        Destroy(obj);
    }

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
