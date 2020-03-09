
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool isPaused = false;
    public Texture tex;
    private void OnGUI()
    {

        if (isPaused)
        {
            if (GUI.Button(new Rect(Screen.width - 100, 40, 80, 40), "Continuer"))
            {
                isPaused = false;
            }
        }
        else
        {
            Time.timeScale = 1f;
            if (GUI.Button(new Rect(Screen.width - 100, 40, 80, 40), "Pause"))
            {
                isPaused = true;
            }
        }
        
        if (GUI.Button(new Rect(Screen.width - 100, 80, 60, 40), "Menu"))
        {
            SceneManager.LoadScene("LoadingScene");
        }
    }
}
