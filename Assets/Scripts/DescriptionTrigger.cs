using UnityEngine;

public class DescriptionTrigger : MonoBehaviour
{
    public GameObject descriptionText;
    public AudioClip enterClip;
    public AudioClip exitClip;

    [Header("Optional Object Spawn")]
    public GameObject objectToSpawn; // The prefab to spawn
    public Transform spawnPoint;     // Where to spawn it

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (descriptionText != null)
        {
            descriptionText.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger.");

            // Show text
            if (descriptionText != null) descriptionText.SetActive(true);

            // Play sound
            if (audioSource != null && enterClip != null)
            {
                audioSource.clip = enterClip;
                audioSource.Play();
            }

            // Spawn object
            if (objectToSpawn != null && spawnPoint != null)
            {
                Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited the trigger.");

            // Hide text
            if (descriptionText != null) descriptionText.SetActive(false);

            // Play sound
            if (audioSource != null && exitClip != null)
            {
                audioSource.clip = exitClip;
                audioSource.Play();
            }
        }
    }
}
