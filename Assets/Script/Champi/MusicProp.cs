using System.Collections;
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
    #region Les Variables
    private GameObject objet; // Le gameobject visé
    private AudioSource src;  // L'AudioSource de ce gameobject
    public bool isLooping;
    private string choix; // Si looping ou non

    // Intervalle en secondes entre 2 chansons.
    public int intervalle;

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
    #endregion

    void Start()
    {
        // On prend le nom du GameObject qui a été visé et on cherche le GameObject du même nom.
        // C'est sur ce gameObject qu'on va appliquer les modifications.
        objet = GameObject.Find(PlayerPrefs.GetString("name"));
        src = objet.GetComponent<AudioSource>();

        // On récupère la valeur d'intervalle entre les chansons.
        intervalle = objet.GetComponent<ChangementScene>().intervalle;

        // On récupère la composente Looping de l'AudioSource et on définit les propriétés qui vont avec.
        isLooping = src.loop;
        src.loop = false; // On retire cette composante car on va seulement utiliser isLooping à partir de maintenant.
        mode(isLooping); // On passe dans le mode associé
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

        // Bouton pour valider.
        if (GUI.Button(new Rect(Screen.width - 190, Screen.height - 40, 180, 30), "Validation du choix"))
        {
            SceneManager.LoadScene("SceneP");
        }

        // Si on est en mode Looping alors ce bouton apparait.
        if (isLooping)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 125, Screen.height / 2, 250, 40), "Intervalle entre chaque loop : " + intervalle + " s")) { }
        }
    }

    public void oneTime()
    {
        // Configuration des variables si la musique est jouée une fois.
        isLooping = false;
        mode(isLooping);
    }

    public void looping()
    {
        // Configuration des variables si la musique est jouée en boucle.
        isLooping = true;
        mode(isLooping);
    }

    public void ajout(int i)
    {
        // On incrémente la variable 'intervalle'
        intervalle += i;
    }

    public void retrait(int i)
    {
        // On décrémente la variable 'intervalle'
        // La variable 'intervalle' est capée en soustraction à 0.
        if (intervalle - i >= 0)
        {
            intervalle -= i;
        }
        else
        {
            intervalle = 0;
        }
    }

    public void mode (bool isLooping)
    {
        // Si le musique est jouée une seule fois alors on désactive tous les boutons et les zones de texte associés.
        // Sinon si la musique doit être jouée en boucle alors on active les boutons et zones de texte nécessaires à cette fonctionnalité.
 
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

        // Ce test if permettra l'affichage de la propriété de la musique sur l'écran
        if (isLooping) {choix = "en boucle";}
        else {choix = "une fois";}
    }
}
