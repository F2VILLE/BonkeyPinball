using UnityEngine;

public class StartButton : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    [SerializeField] private bool isDown = false;

    void FixedUpdate()
    {
        if (isDown && transform.localPosition.y == 0)
        {
            transform.localPosition += new Vector3(0, -1f, 0);
        }
        else if (!isDown && transform.localPosition.y == -1)
        {
            transform.localPosition += new Vector3(0, 1f, 0);
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            Debug.Log("Click !!");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.Log(Physics.Raycast(ray, out hit));
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.name);
                if (hit.transform == transform)
                {
                    Debug.Log("HIT !!");
                    if (!isDown && gameManager.status == GameManagerStatus.STARTING)
                    {
                        isDown = true;
                        gameManager.StartGame();
                    }
                }
            }
        }

        if (gameManager.status == GameManagerStatus.ENDED)
        {
            isDown = false;
        }
    }
}
