using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// contient les données qu'on va vouloir sauvegarder: pour l'instant, que le volume.
/// 
/// 
/// A Ajouter :  les objets et les sons qui sont associés aux volumes, ainsi que les temps de répétition entre deux musiques
/// 
/// 
/// 
/// </summary>
[System.Serializable]
public class VolumeData 
{
    public List<float> slidervalue;  // similaire à celui de pausemenu mais se fera réécrire dessus par la suite, sert à stocker les volumes au moment de la sauvegarde
    public float audiolistsize;//on stocke le nombre d'audios à sauvegarder

    public VolumeData (PauseMenu2 slidos)
    {
        slidervalue = new List<float>();
        audiolistsize = slidos.audiolist.Count;
        for (int i = 0; i < audiolistsize; i++)
        {
            if (GameObject.Find(i.ToString())!=null)
                slidervalue.Add(GameObject.Find(i.ToString()).GetComponent<Slider>().value);
        }
        

    }
}
