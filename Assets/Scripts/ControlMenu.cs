using UnityEngine.SceneManagement;
using UnityEngine;

public class ControlMenu : MonoBehaviour
{
    public void OnStartClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
