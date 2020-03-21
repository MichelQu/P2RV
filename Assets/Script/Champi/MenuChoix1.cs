using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

// Ce script crée l'interface qui permet de choisir la scène sur laquelle se diriger après
// avoir appuyé sur un gameObject pour lui changer de son.

public class MenuChoix1 : MonoBehaviour
{
    private void OnGUI()
    {

        // Création d'une box de BackGround
        GUI.Box(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 112, 300, 255), "Menu de Sélection du Son");

        // Création du bouton vers la scène MusicProp
        if (GUI.Button(new Rect(Screen.width / 2 - 125, Screen.height / 2 - 75, 250, 50), "Propriété de la musique"))
        {
            SceneManager.LoadScene("MusicProp");
        }

        // Création du bouton vers la scène ChoixMusique
        if (GUI.Button(new Rect(Screen.width / 2 - 125, Screen.height / 2 - 5, 250, 50), "Choix de la Musique"))
        {
            SceneManager.LoadScene("ChoixMusique");
        }

        // Création du bouton vers la scène principale
        if (GUI.Button(new Rect(Screen.width / 2 - 125, Screen.height / 2 + 65, 250, 50), "Retour à la Scène Principale"))
        {
            SceneManager.LoadScene("SceneP");
        }
    }
}
