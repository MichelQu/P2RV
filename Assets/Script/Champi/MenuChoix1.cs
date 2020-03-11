using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuChoix1 : MonoBehaviour
{
    private void OnGUI()
    {

        //Création d'une box de BackGround
        GUI.Box(new Rect(Screen.width/2 - 150,Screen.height/2 - 100, 300, 200), "Menu de Sélection du Son");

        if (GUI.Button(new Rect(Screen.width / 2 - 125, Screen.height / 2 - 55, 250, 50), "Choix de la Musique"))
        {
            SceneManager.LoadScene("ChoixMusique");
        }

        if (GUI.Button(new Rect(Screen.width/2 - 125, Screen.height/2 + 15, 250, 50), "Retour à la Scène Principale"))
        {
            SceneManager.LoadScene("SceneP");
        }
    }
}
