using UnityEngine;
using static GameManager;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] private int HP = 10;
    private int[] HPs = new int[2];
    private GameManager manager;

    private void Start()
    {
        manager = Incetance;
        HPs[0] = HP;
        HPs[1] = HP;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("PlayerBullet"))
        {

            //HP -= collision.;
            HPs[1]--;
            manager.gameObject.GetComponent<NamePlateController>().ChangeHPBar(gameObject);

            if (HPs[1] == 0)
            {
                StartCoroutine(manager.gameObject.GetComponent<WaveController>().BrokenEnemy(gameObject));
                gameObject.GetComponent<Collider2D>().enabled = false;
                if (gameObject.GetComponent<EnemyShotBullet>())
                {
                    gameObject.GetComponent<EnemyShotBullet>().enabled = false;
                }
                else if (gameObject.GetComponent<LaserAttacker>())
                {
                    gameObject.GetComponent <LaserAttacker>().enabled = false;
                }


                    HPs[1] = -1;
            }
        }
    }

    public int[] GetHPs()
    {
        return HPs;
    }
}
