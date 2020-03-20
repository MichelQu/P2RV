﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Ce script gère la transition des GameObject essentiels entre les différentes scènes.

public class SauvegardeObjet : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        GameObject[] go1 = GameObject.FindGameObjectsWithTag("Object");

        if (SceneManager.GetActiveScene().name != "SceneP")
        {
            foreach (GameObject item in go1)
            {
                Renderer rend = item.GetComponent<Renderer>();
                rend.enabled = false;
                if (SceneManager.GetActiveScene().name != "MenuChoix" && SceneManager.GetActiveScene().name != "ChoixMusique")
                {
                    AudioSource audioS = item.GetComponent<AudioSource>();
                    audioS.volume = 0;
                }
            }
        }
        else
        {
            foreach (GameObject item in go1)
            {
                Renderer rend = item.GetComponent<Renderer>();
                rend.enabled = true;
                // On remet le son
                AudioSource audioS = item.GetComponent<AudioSource>();
                audioS.volume = 1;
            }
        }
    }
}
