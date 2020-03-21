using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ce script permet de réaliser le changement de musique sur un gameObject
// si l'on a souhaité le changement de son.

public class ChangementReelDeMusique : MonoBehaviour
{
    // Liste des pistes audio
    private Object[] AC1;
    public List<AudioClip> audioClips;

    private void Start()
    {
        // On récupère tous les audioclip dans la base de données et on les ajoute dans la liste d'Audioclip
        AC1 = Resources.LoadAll("Audio", typeof(AudioClip));
        audioClips = new List<AudioClip>();
        foreach(Object item in AC1)
        {
            AudioClip w = (AudioClip)item;
            audioClips.Add(w);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // On récupère les différentes informations entre les scènes.
        string nomObjet = PlayerPrefs.GetString("name");
        string nomSon = PlayerPrefs.GetString("MusicName");
        int numMusic = PlayerPrefs.GetInt("MusicNum");

        // Si les conditions sont permises, on remplace l'audioclip sur le GameObject
        if (nomSon != null)
        {
            if (nomObjet != null)
            {
                GameObject go = GameObject.Find(nomObjet);
                AudioClip clipChoisi = audioClips[numMusic];
                // Debug.Log("Clip Choisi : " + clipChoisi.name);

                if (go != null)
                {
                    AudioSource audio1 = go.GetComponent<AudioSource>();

                    if (clipChoisi != audio1.clip)
                    {
                        audio1.Stop();
                        audio1.clip = clipChoisi;
                        audio1.Play();
                    }
                }
            }
        }
    }
}
