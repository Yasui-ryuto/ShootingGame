using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] private int playerHP = 20;
    private HPBar bar;

    private void Start()
    {
        bar = GameObject.Find("Canvas/HPBack/HPBar/HP").GetComponent<HPBar>();
        if (bar == null )
        {
            Debug.LogError("bar is null");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            playerHP--;
            bar.ChangeHPBarLength();
        }
        if (playerHP < 1)
        {
            Destroy(gameObject);
        }
    }
    
    public int GetHP()
    {
        return playerHP;
    }
}
