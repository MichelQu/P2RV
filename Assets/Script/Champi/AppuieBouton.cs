using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Si on appuie sur un des QR Code dans la scène Configuration, ce script
// redirige l'opérateur vers la scène Configuration2 qui permettra de lui associer un gameObject.

public class AppuieBouton : MonoBehaviour
{
    public Text zoneTexte;

    public void configuration()
    {
        PlayerPrefs.SetString("QRName", zoneTexte.text);
        // Debug.Log(zoneTexte.text);
        SceneManager.LoadScene("Configuration2");
    }
}
