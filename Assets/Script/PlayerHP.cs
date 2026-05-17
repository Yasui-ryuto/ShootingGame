using UnityEngine;

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
        }
        if (playerHP < 1)
        {
            Destroy(gameObject);
        }
    }
    
    public int[] GetPlayerHPs()
    {
        return playerHPs;
    }
}
