using UnityEngine;
using UnityEngine.UI;
using static GameManager;

public class HPBar : MonoBehaviour
{
    private float maxHP;
    private float maxHPBarLength;
    private float startX;
    private void Start()
    {
        maxHP = player.GetComponent<PlayerHP>().GetHP();
        maxHPBarLength = transform.localScale.x;
        startX = transform.position.x;
    }
    public void ChangeHPBarLength()
    {
        int HP = player.GetComponent<PlayerHP>().GetHP();
        Debug.Log(HP + " " + maxHP + " " + HP / maxHP);
        //transform.localScale = new Vector3((HP / maxHP) * maxHPBarLength, transform.localScale.y, transform.localScale.z);
        //transform.position = new Vector3(startX * (HP / maxHP), transform.position.y, transform.position.z);

        GetComponent<Image>().fillAmount = HP / maxHP;
    }
}
