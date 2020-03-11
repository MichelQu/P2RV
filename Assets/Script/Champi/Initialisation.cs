using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Initialisation : MonoBehaviour
{
    // private Object[] obj;

    //private void OnGUI()
    //{
    //    if (GUI.Button(new Rect(Screen.width - 190, 10, 180, 30), "Réinitialisation"))
    //    {
    //        // On réattribue les musiques originelles aux gameObjects
    //        GameObject[] go1 = GameObject.FindGameObjectsWithTag("Object");
    //        Debug.Log("Nombre d'objets : " + go1.Length);
    //        foreach (GameObject item in go1)
    //        {
    //            // Trouver tous les GO avec le même nom
    //            string nom = item.name;
    //            // Chemin
    //            string chemin = "Prefabs/" + nom;
    //            // Debug.Log("Chemin :" + chemin);
    //            // Sauvegarder leur position
    //            Transform pos = item.transform;
    //            // Instancier de nouveaux GO au même endroit, avec musique d'origine"
    //            GameObject instance = Instantiate(Resources.Load(nom, typeof(Object)), pos) as GameObject;
    //        }

    //        foreach (GameObject item in go1)
    //        {
    //            Destroy(item);
    //        }

    //        // On retire toutes les sauvergardes d'ancien choix
    //        PlayerPrefs.DeleteKey("name");
    //        PlayerPrefs.DeleteKey("MusicNum");
    //        PlayerPrefs.DeleteKey("MusicName");
    //    }
    //}


    // TODO rajouter un script pour lors de la réinitialisation
    // on puisse remettre les musiques de base du GameObject

    private void OnGUI()
    {
        //Création d'une box de BackGround
        GUI.Box(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 125, 300, 275), "Menu de Départ");

        if (GUI.Button(new Rect(Screen.width / 2 - 125, Screen.height / 2 - 75, 250, 50), "Vers la Scène Principale"))
        {
            SceneManager.LoadScene("SceneP");
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 125, Screen.height / 2 - 5, 250, 50), "Réinitialisation"))
        {
            PlayerPrefs.DeleteKey("name");
            PlayerPrefs.DeleteKey("MusicNum");
            PlayerPrefs.DeleteKey("MusicName");
            PlayerPrefs.DeleteKey("QRName");
            Debug.Log("Réinitialisation des PlayerPrefs!");
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 125, Screen.height / 2 + 65, 250, 50), "Configuration des QR Codes"))
        {
            SceneManager.LoadScene("Configuration");
        }
    }
}
