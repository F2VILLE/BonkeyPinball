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

    [SerializeField] private GameObject startMenuBackground;
    [SerializeField] private GameObject startMenuTitle;
    [SerializeField] private GameObject startMenuSubtitle;

    private bool startAnimation = false;
    public void StartGame()
    {
        // UIStartingParent.SetActive(false);
        startAnimation = true;
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
        if (startAnimation)
        {

            startMenuTitle.transform.localScale = Vector3.Lerp(startMenuTitle.transform.localScale, new Vector3(0f, 0f, 0f), Time.deltaTime * 8f);
            startMenuSubtitle.transform.position = Vector3.Lerp(startMenuSubtitle.transform.position, new Vector3(-50f, startMenuSubtitle.transform.position.y, startMenuSubtitle.transform.position.z), Time.deltaTime * 1f);
            startMenuBackground.transform.localScale = Vector3.Lerp(startMenuBackground.transform.localScale, new Vector3(37f, 37f, 37f), Time.deltaTime * 2f);
            if (startMenuBackground.transform.localScale.x >= 37f && startMenuBackground.transform.localScale.y >= 37f && startMenuBackground.transform.localScale.z >= 37f)
            {
                startMenuBackground.transform.localScale = new Vector3(37f, 37f, 37f);
                startAnimation = false;
                UIStartingParent.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (status == GameManagerStatus.STARTED)
            {
                PauseGame();
            }
            else if (status == GameManagerStatus.PAUSED)
            {
                ResumeGame();
            }
        }
    }
}
