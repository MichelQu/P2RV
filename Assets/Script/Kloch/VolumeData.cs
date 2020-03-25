using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class VolumeData 
{
    public List<float> slidervalue;
    public float audiolistsize;

    public VolumeData (PauseMenu2 slidos)
    {
        slidervalue = new List<float>();
        for (int i = 0; i < slidos.audiolist.Count; i++)
        {
            if (GameObject.Find(i.ToString())!=null)
                slidervalue.Add(GameObject.Find(i.ToString()).GetComponent<Slider>().value);
        }
        

        audiolistsize = slidos.audiolist.Count;
    }
}
