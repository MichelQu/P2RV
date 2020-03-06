using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionMusique : MonoBehaviour
{
    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width - 190, 10, 180, 30), "Retour à la Scène Principale"))
        {
            SceneManager.LoadScene("SceneP");
        }
    }
}
