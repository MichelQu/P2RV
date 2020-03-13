using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneConfiguration : MonoBehaviour
{
    private void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width - 150, 15, 130, 35), "Menu Principal"))
        {
            SceneManager.LoadScene("Intro");
        }
    }
}
