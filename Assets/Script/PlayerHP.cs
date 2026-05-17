using UnityEngine;
using static GameManager;

public class PlayerHP : MonoBehaviour
{ 
    [SerializeField] private int playerHP = 20;
    private int[] playerHPs = new int[2];

    private void Start()
    {
        playerHPs[0] = playerHP;
        playerHPs[1] = playerHP;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            playerHPs[1]--;
            GameManager.Incetance.GetComponent<NamePlateController>().ChangeHPBar(gameObject);
        }
        if (playerHPs[1] < 1)
        {
            Destroy(gameObject);
        }
    }
    
    public int[] GetPlayerHPs()
    {
        return playerHPs;
    }
}
