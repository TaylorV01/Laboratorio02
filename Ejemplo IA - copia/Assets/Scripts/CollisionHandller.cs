using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CollisionHandler : MonoBehaviour
{
    public TextMeshProUGUI messageText; // Assign the TextMeshPro object in the Unity Inspector

    private bool isWaitingForReset = false;

    void Start()
    {
        // Initially, the messageText should be hidden
        messageText.gameObject.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Map"))
        {
            ActivateMessage("Has perdido, Presiona enter reintentar");
        }
        else if (collision.gameObject.CompareTag("Objective"))
        {
            ActivateMessage("¡Has ganado!, Presiona enter reintentar");
        }
    }

    void Update()
    {
        // If waiting for reset and Enter key is pressed
        if (isWaitingForReset && Input.GetKeyDown(KeyCode.Return))
        {
            ResetScene();
        }
    }

    void ActivateMessage(string message)
    {
        // Activate the message TextMeshPro object and set the message
        messageText.text = message;
        messageText.gameObject.SetActive(true);
        isWaitingForReset = true;
    }

    void ResetScene()
    {
        // Reload the current scene to reset it
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
