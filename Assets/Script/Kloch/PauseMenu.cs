
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
            if (GUI.Button(new Rect(Screen.width - 150, 15, 130, 35), "Continuer"))
            {
                isPaused = false;
            }
        }
        else
        {
            Time.timeScale = 1f;
            if (GUI.Button(new Rect(Screen.width - 150, 15, 130, 35), "Pause"))
            {
                isPaused = true;
            }
        }
        
        if (GUI.Button(new Rect(25, 15, 130, 35), "Menu"))
        {
            SceneManager.LoadScene("Intro");
        }
    }
}
