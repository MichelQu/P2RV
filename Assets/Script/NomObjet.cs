using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NomObjet : MonoBehaviour
{
	public Text zoneText;
    public int placement;
    private string selectedName;

    void Start()
    {
        zoneText.transform.position = new Vector3(Screen.width / 2, (Screen.height / 2 + placement), 0);
        selectedName = PlayerPrefs.GetString("name");
        zoneText.text = "Objet sélectionné : " + selectedName;
    }

    // Update is called once per frame
    private void Update()
    {
        Debug.Log(selectedName);
    }
}
