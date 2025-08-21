using System;
using UnityEngine;

public class SpringShot : MonoBehaviour

{
    [SerializeField] private float launchForce = 10f;
    [SerializeField] private AudioClip launchSound;
    [SerializeField] private GameObject forceGauge;
    private bool isBallInTrigger = false;
    private bool isKeyPressed = false;
    private float keyPressTime = 0f;

    void Start()
    {
        Debug.Log("SpringShot initialized.");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isBallInTrigger)
        {
            isKeyPressed = true;
            keyPressTime = Time.time;
        }
        if (Input.GetKeyUp(KeyCode.Space) && isKeyPressed)
        {
            isKeyPressed = false;
            float holdDuration = Time.time - keyPressTime;
            Debug.Log("Space key held for: " + holdDuration + " seconds");
            LaunchBall(Math.Clamp(holdDuration, 0.1f, 1f));
        }

        if (forceGauge)
        {
            forceGauge.transform.localScale = new Vector3(1f, 1f, Mathf.Clamp01((Time.time - keyPressTime) / 1f));
            if (isKeyPressed)
            {
                forceGauge.SetActive(true);
            }
            else
            {
                forceGauge.SetActive(false);
            }
        }
    }


    void LaunchBall(float multi = 1f)
    {
        GameObject ball = GameObject.FindGameObjectWithTag("Ball");
        if (ball != null)
        {
            Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
            if (ballRigidbody != null)
            {
                if (launchSound)
                {
                    AudioSource.PlayClipAtPoint(launchSound, transform.position);
                }
                float launchDelay = 1f;
                float timer = 0f;
                while (timer < launchDelay)
                {
                    timer += Time.fixedDeltaTime;
                }
                ballRigidbody.AddForce(Vector3.forward * launchForce * multi, ForceMode.Impulse);

                Debug.Log("Ball launched with force: " + launchForce * multi);
            }
            else
            {
                Debug.LogWarning("No Rigidbody found on the ball.");
            }
        }
        else
        {
            Debug.LogWarning("No ball found in the scene.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            isBallInTrigger = true;
            Debug.Log("Ball entered the spring trigger area.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            isBallInTrigger = false;
            Debug.Log("Ball exited the spring trigger area.");
        }
    }
}
