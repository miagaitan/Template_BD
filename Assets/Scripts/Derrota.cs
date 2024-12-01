using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Derrota : MonoBehaviour
{
    public Button _Button;

    void Start()
    {
        // Ensure the button is interactable
        if (_Button != null)
        {
            Debug.Log("Button is assigned!");
        }
        else
        {
            Debug.LogError("Button is not assigned in the Inspector!");
        }
    }
    public void PreviousScene()
    {
        Destroy(GameManager.Instance);
        Destroy(UIManagment.Instance);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }


}
