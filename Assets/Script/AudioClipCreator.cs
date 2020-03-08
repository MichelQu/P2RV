﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioClipCreator : MonoBehaviour
{

    public List<AudioClip> audioclip;
    // public GameObject parent;
    private int hauteurBase = 90;
    private int longueurBase = 50;

    // TODO
    // Système de fenêtre à rajouter avec page suivante ou page antérieur
    // À faire avec une variable qui donne le numéro de la page.
    // Page suivante apparait dès que le nombre limite de chansons et rentrer
    // Page antérieur dès qu'on est à la page 2 ou plus

    void OnGUI()
    {
        int i = 0;

        foreach (AudioClip item in audioclip)
        {
            if (i > 20 && i < 42)
            {
                if (GUI.Button(new Rect(Screen.width - 175, Screen.height - 50, 150, 30), "Page suivante"))
                {

                }
            }

            // Debug.Log(item.name);
            if  (i < 21)
            {
                if (GUI.Button(new Rect(longueurBase, hauteurBase, 180, 30), item.name))
                {
                    PlayerPrefs.SetString("MusicName", item.name);
                    PlayerPrefs.SetInt("MusicNum", i);
                    // Debug.Log(PlayerPrefs.GetString("MusicName"));
                    SceneManager.LoadScene("SceneP");
                }

                hauteurBase += 40;
                i += 1;
                if (i % 7 == 0)
                {
                    hauteurBase = 90;
                    longueurBase += 200;
                }
            }
        }

        hauteurBase = 90;
        longueurBase = 50;
    }
}
