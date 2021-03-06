﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Ce script place le nom du GameObject sélectionné dans une zone de Texte.
// Dans les scènes suivantes à la scène Principale.

public class NomObjet2 : MonoBehaviour
{
    public Text zoneText;
    public int placement;
    private string selectedName;

    // Update is called once per frame
    private void Update()
    {
        zoneText.transform.position = new Vector3(Screen.width / 2, Screen.height - placement, 0);

        // TODO régler les tops et bottoms de la zone de Texte pour garder une box de taille constante
        // Et éviter une disparition de la box lorsque qu'on diminue trop la taille de l'écran.

        // zoneText.rectTransform.rect.
        selectedName = PlayerPrefs.GetString("name");
        zoneText.text = "Objet sélectionné : " + selectedName;
    }
}
