using TMPro;
using UnityEngine;

public class GameStartTextController : MonoBehaviour
{
    private void Update()
    {
        //テキストを点滅させる
        GetComponent<TextMeshProUGUI>().color = new Color(1.0f, 1.0f, 1.0f, (float)Mathf.Abs(Mathf.Sin(Time.time % 360)));
    }
}
