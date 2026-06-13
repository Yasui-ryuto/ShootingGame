using UnityEngine;
using UnityEngine.UI;
using static GameManager;

public class NamePlate : MonoBehaviour
{
    private GameObject HPBar;
    private bool isStart = true;

    [SerializeField] private float HPBarInc = 0.1f;
    private float amount = 0;

    private void Start()
    {
        HPBar = transform.Find("NamePlateBack/HPBarBack/HPBar").gameObject; //HPBarのオブジェクト
    }

    private void Update()
    {
        if (Incetance.situation != Situation.Pause)
        {
            if (isStart)
            {
                amount += HPBarInc;
                HPBar.GetComponent<Image>().fillAmount = amount; //HPBarの長さ
                if (amount > 1)
                {
                    GameManager.Incetance.GetComponent<NamePlateController>().SetbarStart(true);
                    isStart = false;
                }
            }
        }
    }
}
