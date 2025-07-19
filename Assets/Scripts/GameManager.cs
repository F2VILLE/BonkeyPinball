using UnityEngine;

public enum GameManagerStatus
{
    STARTING = 0,
    STARTED = 1,
    PAUSED = 2,
    ENDED = 3

}

public class GameManager : MonoBehaviour
{
    public GameManagerStatus status = GameManagerStatus.STARTING;

    [SerializeField] private GameObject UIStartingParent;
    [SerializeField] private GameObject UIGameParent;


    public void StartGame()
    {
        UIStartingParent.SetActive(false);
        status = GameManagerStatus.STARTED;
    }

    public void PauseGame()
    {
        status = GameManagerStatus.PAUSED;
    }

    public void ResumeGame()
    {
        status = GameManagerStatus.STARTED;
    }

    public void EndGame()
    {
        status = GameManagerStatus.ENDED;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
