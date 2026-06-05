using UnityEngine;
using static GameManager;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject reStartButton;
    private GameManager manager;
    private Situation tempSitu = Situation.GameInterval;

    private void Start()
    {
        manager = Incetance;
        pauseButton.SetActive(true);
        reStartButton.SetActive(false);
    }

    public void PauseFinish()
    {
        pauseButton.SetActive(true);
        reStartButton.SetActive(false);
        Time.timeScale = 1.0f;
        manager.situation = tempSitu;
    }

    public void PauseStart()
    {
        tempSitu = manager.situation;
        manager.situation = Situation.Pause;
        pauseButton.SetActive(false);
        reStartButton.SetActive(true);
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
