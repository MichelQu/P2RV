using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Ce script place le nom du GameObject sélectionné dans une zone de Texte.
// Dans les scènes suivantes à la scène de Configuration.

public class NomObjetBis : MonoBehaviour
{
    public Text zoneText;
    public int placementW, placementH;
    private string selectedName;

    // Update is called once per frame
    private void Update()
    {
        zoneText.transform.position = new Vector3(Screen.width / 2 - placementW, Screen.height - placementH, 0);

        // TODO régler les tops et bottoms de la zone de Texte pour garder une box de taille constante
        // Et éviter une disparition de la box lorsque qu'on diminue trop la taille de l'écran.

        // zoneText.rectTransform.rect.

        selectedName = PlayerPrefs.GetString("ConfigGO");
        zoneText.text = "Object sélectionné : " + selectedName;
    }
}
