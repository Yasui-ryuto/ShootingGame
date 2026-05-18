using System.Collections;
using UnityEngine;
using static GameManager;

public class PlayerHP : MonoBehaviour
{ 
    [SerializeField] private int playerHP = 20;
    private int[] playerHPs = new int[2];

    [SerializeField] private ParticleSystem[] diedEffect;

    private void Start()
    {
        playerHPs[0] = playerHP;
        playerHPs[1] = playerHP;
        diedEffect = new ParticleSystem[transform.childCount];
        for(int i = 0; i < diedEffect.Length; i++)
        {
            diedEffect[i] = transform.GetChild(i).gameObject.GetComponent<ParticleSystem>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            playerHPs[1]--;
            GameManager.Incetance.GetComponent<NamePlateController>().ChangeHPBar(gameObject);
        }
        if (playerHPs[1] == 0)
        {
            StartCoroutine(DiedEffect());
            playerHPs[1] = -1;
        }
    }

    private IEnumerator DiedEffect()
    {
        foreach(var effect in diedEffect)
        {
            effect.Play();
        }

        yield return new WaitWhile(() => diedEffect[1].IsAlive(true));

        Destroy(gameObject);
    }
    
    public int[] GetPlayerHPs()
    {
        return playerHPs;
    }
}
