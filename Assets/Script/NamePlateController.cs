using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NamePlateController : MonoBehaviour
{
    private GameManager manager;

    [SerializeField] private GameObject Canvas;
    [SerializeField] private GameObject namePlatePrefab;
    private bool barStart = false;

    private void Start()
    {
        manager = GameManager.Incetance;
    }
    /// <summary>
    /// HPBarの初期演出
    /// </summary>
    /// <returns></returns>
    public IEnumerator StartHPBar()
    {
        //HPBarの作成
        for (int i = 0; i < manager.enemy.Length; i++)
        {
            if (manager.enemy[i] != manager.empty)
            {
                manager.HPBars[i] = Instantiate(namePlatePrefab, Canvas.transform); //HPBarのプレハブの追加（親をCanvasに設定）
                manager.HPBars[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(-740f, 480f - (i * 100)); //HPBarの場所
                manager.HPBars[i].transform.Find("NamePlateBack/Name").GetComponent<TextMeshProUGUI>().text = manager.enemy[i].name; //HPBarに書かれる名前の変更
            }
        }

        yield return new WaitUntil(() => barStart); //barStartがtrueになるまで待機
    }


    public void SetbarStart(bool boolean)
    {
        barStart = boolean;
    }

    public void ChangeHPBar(GameObject obj)
    {
        if (obj.CompareTag("Player"))
        {
            int[] playerHPs = obj.GetComponent<PlayerHP>().GetPlayerHPs();

            Canvas.transform.Find("PlayerNamePlatNamePlateBack/HPBarBack/HPBar").GetComponent<Image>().fillAmount = (float)playerHPs[1] / (float)playerHPs[0]; //HPBarの長さ
        }
        else
        {
            int[] HPs = obj.GetComponent<EnemyHP>().GetHPs();

            for (int i = 0; i < manager.enemy.Length; i++)
            {
                if (manager.enemy[i] == obj)
                {
                    manager.HPBars[i].transform.Find("NamePlateBack/HPBarBack/HPBar").GetComponent<Image>().fillAmount = (float)HPs[1] / (float)HPs[0]; //HPBarの長さ
                    break;
                }
            }
            //HPBar.GetComponent<Image>().fillAmount = (float)(HPs[1] / HPs[0]); //HPBarの長さ
        }
    }

}
