using UnityEngine;
using static GameManager;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private GameObject controlGuide;
    private GameManager manager;
    private Situation tempSitu = Situation.GameInterval;

    private void Start()
    {
        manager = Incetance;
        controlGuide.SetActive(true);
        manager.situation = Situation.ControllerGuide;
    }

    public void CloseGuide()
    {
        controlGuide.SetActive(false);
        Time.timeScale = 1.0f;
        manager.situation = tempSitu;
    }

    public void OpenGuide()
    {
        if(tempSitu == Situation.ControllerGuide)
        {
            tempSitu = Situation.GameInterval;
        }
        else
        {
            tempSitu = manager.situation;
        }
        manager.situation = Situation.ControllerGuide;
        controlGuide.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void ContinueButton()
    {
        manager.situation = Situation.GameInterval;
        manager.gameOver.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
