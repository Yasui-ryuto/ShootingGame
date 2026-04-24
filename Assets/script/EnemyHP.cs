using UnityEngine;
using static GameManager;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] private int HP = 10;
    private GameManager manager;

    private void Start()
    {
        manager = Incetance;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("PlayerBullet"))
        {

            //HP -= collision.;
            HP--;

            Debug.Log(HP);

            if (HP <= 0)
            {
                StartCoroutine(manager.BrokenEnemy(gameObject));
                gameObject.GetComponent<Collider2D>().enabled = false;
                gameObject.GetComponent<EnemyShotBullet>().enabled = false;
            }
        }
    }
}
