﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Ce script crée le bouton qui permet de retourner vers la scène
// d'Introduction depuis la scène Configuration1.

public class SceneConfiguration : MonoBehaviour
{
    private void OnGUI()
    {
        // On crée un bouton qui permet de venir vers le menu principal, la scène d'Intro
        if (GUI.Button(new Rect(Screen.width - 150, 15, 130, 35), "Menu Principal"))
        {
            SceneManager.LoadScene("Intro");
        }
    }
}
