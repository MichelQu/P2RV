using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangementReelDeMusique : MonoBehaviour
{
    // Liste des pistes audio
    public List<AudioClip> audioclip;

    // Update is called once per frame
    void Update()
    {
        string nomObjet = PlayerPrefs.GetString("name");
        // Debug.Log("nom de l'Objet : " + nomObjet);
        string nomSon = PlayerPrefs.GetString("MusicName");
        // Debug.Log("Nom du son : " + nomSon);
        int numMusic = PlayerPrefs.GetInt("MusicNum");
        // Debug.Log("Numéro de la musique : " + numMusic);

        if (nomSon != null)
        {
            if (nomObjet != null)
            {
                GameObject go = GameObject.Find(nomObjet);     
                AudioClip clipChoisi = audioclip[numMusic];
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
