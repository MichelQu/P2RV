using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Ce script permet de réaliser le changement de scène pour réaliser un
// changement de musique. Le script s'active seulement si le menu Pause est désactivé.

public class ChangementScene : MonoBehaviour
{
    private bool isPaused; // Le booléen 'Pause'

    public int intervalle = 0; // Nombre de temps d'intervalle entre les loop de la musique.
    private bool isLooping = true; // Toutes les musiques sont joués avec un loop

    private AudioSource src; // Audiosource du gameObject

    private void Start()
    {
        src = gameObject.GetComponent<AudioSource>(); // On récupère l'audiosource du gameObject
        src.loop = isLooping;
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "MusicProp")
        {
            // On récupère la composante intervalle modifié dans la scène MusicProp
            Camera cam = Camera.main;
            intervalle = cam.GetComponent<MusicProp>().intervalle;
            // Debug.Log("Intervalle : " + intervalle);
            isLooping = cam.GetComponent<MusicProp>().isLooping;
            // src.loop = isLooping; // On lui associe sa valeur donné dans le script MusicProp
        }

        // Si le morceau tourne en boucle,
        if (isLooping)
        {
            // Si le morceau n'est plus entrain de jouer.
            if (!src.isPlaying)
            {
                AudioClip musique = src.clip;
                // On attend l'intervalle de temps entre 2 morceaux.
                StartCoroutine(waitAndPlay(intervalle,musique));
            }
        }
    }

    private IEnumerator waitAndPlay(int temps, AudioClip musique)
    {
        // On s'assure que le clip ne joue plus.
        src.Stop();
        // On attend l'intervalle voulu
        yield return new WaitForSeconds(temps);
        // On joue rejoue la musique
        src.PlayOneShot(musique, 1.0f);
    }


    // Fonction qui s'active sur clic sur le gameObject
    private void OnMouseDown()
    {
        // On récupère la composente isPaused si on est dans la bonne scène.
        if (SceneManager.GetActiveScene().name == "SceneP")
        {
            GameObject Cam = GameObject.FindGameObjectWithTag("MainCamera");
            isPaused = Cam.GetComponent<PauseMenu2>().isPaused;
        }

        // Si les conditions sont réunies, lorsqu'on réalise un clic droit
        // On récupère les informations du GameObject et on bascule vers la scène MenuChoix.
        if (!isPaused)
        {
            // On configure la variables et la clé "name"
            PlayerPrefs.SetString("name", gameObject.name);
            SceneManager.LoadScene("MenuChoix");
        }
    }
}

