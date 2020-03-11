using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NomObjet : MonoBehaviour
{
	public Text zoneText;
    public int placement;
    private string selectedName;

    // Update is called once per frame
    private void Update()
    {
        // TODO à modifier pour qu'il s'adapte aux changement de taille de l'écran.
        // Il faudra trouver les informations des zoneText

        zoneText.transform.position = new Vector3(Screen.width / 2, (Screen.height / 2 + placement), 0);
        selectedName = PlayerPrefs.GetString("name");
        zoneText.text = "Objet sélectionné : " + selectedName;
    }
}
