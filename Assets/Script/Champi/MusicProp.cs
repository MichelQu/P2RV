﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

// Avec ce script, nous allons pouvoir observer les propriétés des sons associés au gameObject.
// Nous allons également pouvoir les modifier.

public class MusicProp : MonoBehaviour
{
    private GameObject objet; // Le gameobject visé
    private AudioSource src;  // L'AudioSource de ce gameobject
    private bool isLooping;
    private string choix; // Si looping ou non

    // Intervalle en secondes entre 2 chansons.
    private int intervalle = 0;

    // Liste des boutons et textes
    public Button cinqPlus;
    public Button cinqMoins;
    public Button quinzePlus;
    public Button quinzeMoins;
    public Button minutePlus;
    public Button minuteMoins;

    public GameObject cinq;
    public GameObject quinze;
    public GameObject minute;

    void Start()
    {
        // On prend le nom du GameObject qui a été visé et on cherche le GameObject du même nom.
        // C'est sur ce gameObject qu'on va appliquer les modifications.
        objet = GameObject.Find(PlayerPrefs.GetString("name"));
        src = objet.GetComponent<AudioSource>();
    }

    void Update()
    {
        isLooping = src.loop;
        // Ce if permettra l'affichage de la propriété de la musique sur l'écran
        if (isLooping)  { choix = "en boucle";}
        else            { choix = "une fois"; }

        if (!isLooping)
        {
            cinq.SetActive(false);
            quinze.SetActive(false);
            minute.SetActive(false);
            cinqPlus.interactable = false;
            cinqMoins.interactable = false;
            quinzePlus.interactable = false;
            quinzeMoins.interactable = false;
            minutePlus.interactable = false;
            minuteMoins.interactable = false;
        }
        else
        {
            cinq.SetActive(true);
            quinze.SetActive(true);
            minute.SetActive(true);
            cinqPlus.interactable = true;
            cinqMoins.interactable = true;
            quinzePlus.interactable = true;
            quinzeMoins.interactable = true;
            minutePlus.interactable = true;
            minuteMoins.interactable = true;
        }
    }

    private void OnGUI()
    {
        // Affichage des textes suivants.
        if( GUI.Button(new Rect(Screen.width / 2 - 125, Screen.height/2 - 200, 250, 40), "Choix des propriétés du son")) { }
        if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 140, 300, 40), "Actuellement, la musique est jouée " + choix)) { }

        // Bouton pour revenir au Menu Choix.
        if (GUI.Button(new Rect(Screen.width - 190, 10, 180, 30), "Retour au Menu Choix"))
        {
            SceneManager.LoadScene("MenuChoix");
        }

        if (isLooping)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 125, Screen.height / 2, 250, 40), "Intervalle entre chaque loop : " + intervalle + " s")) { }
        }
    }

    public void oneTime()
    {
        src.loop = false;
    }

    public void looping()
    {
        src.loop = true;
    }

    public void ajout(int i)
    {
        intervalle += i;
    }

    public void retrait(int i)
    {
        if (intervalle - i >= 0)
        {
            intervalle -= i;
        }
        else
        {
            intervalle = 0;
        }
    }
}
