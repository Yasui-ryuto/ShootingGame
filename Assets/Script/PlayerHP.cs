using System.Collections;
using UnityEngine;
using static GameManager;

public class PlayerHP : MonoBehaviour
{ 
    [SerializeField] private int playerHP = 20;
    private int[] playerHPs = new int[2];

    [SerializeField] private GameObject[] diedEffect;
    [SerializeField] private GameObject damageEffect;

    private void Start()
    {
        playerHPs[0] = playerHP;
        playerHPs[1] = playerHP;
        //diedEffect = new ParticleSystem[transform.childCount];
        //for(int i = 0; i < diedEffect.Length; i++)
        //{
        //    diedEffect[i] = transform.GetChild(i).gameObject.GetComponent<ParticleSystem>();
        //}
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            playerHPs[1]--;
            StartCoroutine(DamageEffect(other.gameObject));
            GameManager.Incetance.GetComponent<NamePlateController>().ChangeHPBar(gameObject);
        }
        if (playerHPs[1] == 0)
        {
            playerHPs[1] = -1;
            StartCoroutine(GameManager.Incetance.gameObject.GetComponent<WaveController>().DiedEffect(gameObject, diedEffect));
        }
    }
    private IEnumerator DamageEffect(GameObject bullet)
    {
        ParticleSystem effect = Instantiate(damageEffect, player.transform).GetComponent<ParticleSystem>();
        effect.transform.position = bullet.transform.position;
        effect.Play();

        yield return new WaitWhile(() => effect.IsAlive());

        Destroy(effect);
    }

    //private IEnumerator DiedEffect()
    //{
    //    foreach(var effect in diedEffect)
    //    {
    //        Instantiate()
    //        effect.Play();
    //    }

    //    transform.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);

    //    yield return new WaitWhile(() => diedEffect[1].IsAlive(true));

    //    Destroy(gameObject);
    //}
    
    public int[] GetPlayerHPs()
    {
        return playerHPs;
    }
}
