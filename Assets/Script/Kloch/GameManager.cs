using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// sert à appeler les fonctions de sauvegarde et chargement: on doit créer deux boutons de sauvegarde et de chargement auxquels attacher les deux fonctions.
/// </summary>
public class GameManager : MonoBehaviour
{
    public void SaveVolume()
    {
        
        SaveSystem.SaveVolume(GameObject.Find("Main Camera").GetComponent<PauseMenu2>());
    }

    public void LoadVolume()  //sert à correctement affecter toutes les valeurs de volume sitot qu'on va cliquer sur le bouton load
    {
        VolumeData data = SaveSystem.LoadVolume();
        PauseMenu2 slidos = GameObject.Find("Main Camera").GetComponent<PauseMenu2>();

        slidos.slidervalue = new List<float>();
        for (int i = 0; i < data.audiolistsize; i++)
        {
            
            slidos.audiolist[i].volume = data.slidervalue[i];  // gère pendant qu'il n'y  a pas pause
            slidos.slidervalue.Add(data.slidervalue[i]);
                
            
            if (GameObject.Find(i.ToString()) != null)
            {
                Slider slidi = GameObject.Find(i.ToString()).GetComponent<Slider>(); //gère la situation pendant la pause
                slidi.value=data.slidervalue[i];
            }
        }

    }


}
