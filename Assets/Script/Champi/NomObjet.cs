﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NomObjet : MonoBehaviour
{
	public Text zoneText;
    private string selectedName;

    // Update is called once per frame
    private void Update()
    {
        zoneText.transform.position = new Vector3(Screen.width/2, Screen.height/2 + 125, 0);

        // TODO régler les tops et bottoms de la zone de Texte pour garder une box de taille constante
        // Et éviter une disparition de la box lorsque qu'on diminue trop la taille de l'écran.

        // zoneText.rectTransform.rect.
        selectedName = PlayerPrefs.GetString("name");
        zoneText.text = "Objet sélectionné : " + selectedName;
    }
}
