using System.Collections;
using UnityEngine;
using static GameManager;

public class PlayerHP : MonoBehaviour
{ 
    [SerializeField] private int playerHP = 20;
    private int[] playerHPs = new int[2];

    [SerializeField] private GameObject[] diedEffect;
    [SerializeField] private GameObject damageEffect;
    [SerializeField] private float damageIntervalTime = 0.2f; //ダメージエリアに入っているときのダメージ間隔(秒)
    [SerializeField] private float damageAreaStay = 0f; //ダメージエリアに入っているフレーム
    private bool damageOn = false; //ダメージエリアに入っているかのフラグ
    private Collider2D col;

    private void Start()
    {
        playerHPs[0] = playerHP; //初期HP
        playerHPs[1] = playerHP; //現在のHP
        //コンティニュー時のHPバーの初期化
        GameManager.Incetance.GetComponent<NamePlateController>().ChangeHPBar(gameObject);
    }

    private void Update()
    {
        //ダメージエリアに入っているとき
        if (damageOn)
        {
            damageAreaStay++;

            if (damageAreaStay > damageIntervalTime * 60)
            {
                playerHPs[1]--;
                StartCoroutine(DamageEffect(col.gameObject));
                GameManager.Incetance.GetComponent<NamePlateController>().ChangeHPBar(gameObject);
                damageAreaStay = 0f;

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyBullet") || other.gameObject.CompareTag("Enemy"))
        {
            playerHPs[1]--;
            StartCoroutine(DamageEffect(other.gameObject));
            GameManager.Incetance.GetComponent<NamePlateController>().ChangeHPBar(gameObject);
        }
        if (playerHPs[1] == 0)
        {
            playerHPs[1] = -1;
            gameObject.GetComponent<Collider2D>().enabled = false;
            StartCoroutine(GameManager.Incetance.gameObject.GetComponent<WaveController>().DiedEffect(gameObject, diedEffect));

        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("EnemyBullet") || other.gameObject.CompareTag("Enemy"))
        {
            if (!damageOn)
            {
                col = other;
                damageOn = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyBullet") || other.gameObject.CompareTag("Enemy"))
        {
            damageAreaStay = 0f;
            damageOn = false;
        }
    }
    private IEnumerator DamageEffect(GameObject bullet)
    {
        //エフェクトの生成と再生
        ParticleSystem effect = Instantiate(damageEffect, Incetance.player.transform).GetComponent<ParticleSystem>();
        effect.transform.position = bullet.transform.position;
        effect.Play();

        yield return new WaitWhile(() => effect.IsAlive()); //エフェクトが再生されている間待つ

        Destroy(effect);
    }
    
    public int[] GetPlayerHPs()
    {
        return playerHPs;
    }
}
