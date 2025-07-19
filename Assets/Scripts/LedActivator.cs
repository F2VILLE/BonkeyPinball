using UnityEngine;

public class LedActivator : MonoBehaviour
{
    [SerializeField] float cooldown = 0.25f;
    float last_trigger = 0f;
    Renderer le_renderer;
    Material material;

    void Start()
    {
        le_renderer = GetComponent<Renderer>();
        material = le_renderer.material;
    }

    void FixedUpdate()
    {
        float delta_time = Time.fixedTime - last_trigger;
        if (delta_time > cooldown)
        {
            if (le_renderer != null)
            {
                if (material != null)
                {
                    material.DisableKeyword("_EMISSION");
                }
            }

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Debug.Log("LED activated by: " + other.gameObject.name);
            if (le_renderer != null)
            {
                if (material != null)
                {
                    last_trigger = Time.fixedTime;
                    material.EnableKeyword("_EMISSION");
                }
            }
        }
    }
}
