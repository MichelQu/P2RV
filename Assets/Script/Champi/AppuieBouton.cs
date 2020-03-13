using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
