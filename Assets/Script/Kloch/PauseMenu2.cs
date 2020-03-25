using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PauseMenu2 : MonoBehaviour
{
    public bool isPaused = false;
    public Texture tex;
    public List<AudioSource> audiolist;
    public List<float> slidervalue;
    private int nbrSliderBouton;
    public Slider slide;
    public Canvas canva;
    public int nbaudio, nbslider;
    private void OnGUI()
    {

        if (isPaused)
        {
            if (GUI.Button(new Rect(Screen.width - 150, 15, 130, 35), "Continuer"))
            {
                isPaused = false;
                slidervalue = new List<float>();
                
                for (int i = 0; i < audiolist.Count; i++)  //on casse tout
                {
                    if (GameObject.Find(i.ToString()) != null)
                    {
                        Slider slidi = GameObject.Find(i.ToString()).GetComponent<Slider>();
                        slidervalue.Add(slidi.value);
                        Destroy(GameObject.Find(i.ToString()));
                    }
                }
            }
            for (int i = 0; i < audiolist.Count; i++)
            {
                CreerBouton(i);
            }
            
            Mute();
            Demute();
        }


        else
        {
            if (GUI.Button(new Rect(Screen.width - 150, 15, 130, 35), "Pause"))
            {
                isPaused = true;
                nbslider = slidervalue.Count;
                for (int i = 0; i < nbslider; i++)
                {
                    Slider slidi = CreerSlider(i);
                    slidi.value = slidervalue[i];
                    slidi.gameObject.name = i.ToString(); 
                }
                for (int i = slidervalue.Count; i < audiolist.Count; i++)
                {
                    Slider slidi = CreerSlider(i);
                    slidi.value = 1;
                    slidi.gameObject.name = i.ToString();
                }
            }
        }

        if (GUI.Button(new Rect(25, 15, 130, 35), "Menu"))
        {
            SceneManager.LoadScene("Intro");
        }
    }


    public void Update()
    {
        GetList();
        nbaudio = audiolist.Count;
        nbrSliderBouton = ((Screen.height - 80) / 35);
        
        for (int i = 0; i < audiolist.Count; i++)
        {
            if (GameObject.Find(i.ToString()) != null)
            {
                Slider slidi = GameObject.Find(i.ToString()).GetComponent<Slider>();
                audiolist[i].volume = slidi.value;
            }
        }

    }


    public void GetList()   // la fonction qui va permettre de choper les Audio qui se jouent 
    {
        AudioSource[] getAudio;
        getAudio = Object.FindObjectsOfType(typeof(AudioSource)) as AudioSource[];  // on prend toutes les audiosource
        audiolist = new List<AudioSource>();
        for (int i = 0; i < getAudio.Length; i++)
        {
            if (getAudio[i].isPlaying)
            {
                audiolist.Add(getAudio[i]);
            }
        }
    }

    public void CreerBouton(int i)
    {
        // Le placement des Boutons se font par rapport au coin gauche du canvas.
        if (i < nbrSliderBouton)
        {
            GUI.Button(new Rect(25, 80 + 35 * i, 120, 30), audiolist[i].name);
        }
        if (i < nbrSliderBouton * 2 && i >= nbrSliderBouton)
        {
            GUI.Button(new Rect(370, 80 + 35 * (i - nbrSliderBouton), 120, 30), audiolist[i].name);
        }
        else
        {
            // À vérifier avec la taille de l'écran final
            GUI.Button(new Rect(715, 80 + 35 * (i - (nbrSliderBouton * 2)), 120, 30), audiolist[i].name);
        }
    }

    public Slider CreerSlider(int i)
    {
        // Le placement des Sliders se font par rapport au centre du canvas.
        Slider slidi;

        if (i < nbrSliderBouton)
        {
            slidi = Instantiate(slide, new Vector3(245, Screen.height - (80 + (35 * i) + 15), 0), Quaternion.identity, canva.transform);
        }
        else if (i < nbrSliderBouton * 2 && i >= nbrSliderBouton)
        {
            slidi = Instantiate(slide, new Vector3(590, Screen.height - (80 + (35 * (i - nbrSliderBouton)) + 15), 0), Quaternion.identity, canva.transform);
        }
        else
        {
            // A vérifier avec la taille de l'écran final
            slidi = Instantiate(slide, new Vector3(925, Screen.height - (80 + (35 * (i - nbrSliderBouton * 2)) + 15), 0), Quaternion.identity, canva.transform);
        }
        return slidi;
    }


    public void Mute()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 130, 25, 110, 35), "Mute all"))
        {
            for (int i = 0; i < audiolist.Count; i++)
            {
                if (GameObject.Find(i.ToString()) != null)
                {
                    Slider slidi = GameObject.Find(i.ToString()).GetComponent<Slider>();
                    slidi.value = 0;
                }
            }
        }
    }

    public void Demute()
    {
        if (GUI.Button(new Rect(Screen.width / 2 + 20, 25, 110, 35), "Demute all"))
        {
            for (int i = 0; i < audiolist.Count; i++)
            {
                if (GameObject.Find(i.ToString()) != null)
                {
                    Slider slidi = GameObject.Find(i.ToString()).GetComponent<Slider>();
                    slidi.value = 1;
                }
            }
        }
    }
}

