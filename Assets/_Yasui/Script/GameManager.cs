using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameObject player;

    private void Awake()
    {
        if(player == null)
        {
            player = GameObject.Find("Player").gameObject;
        }
    }
}
