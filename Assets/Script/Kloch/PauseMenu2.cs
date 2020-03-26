using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// contraction de pausemenu et slidercreator3. slidercreator3 devait être remplacé car ne permettait pas la sauvegarde.
/// La contraction est plus simple.
/// On a donc une distinction entre le menu pause et le menu normal, avec notamment des scripts qui ne s'activent qu'en menu pause et inversement.
/// 
/// Régression par rapport à slidercreator3: on ne gère pas l'ajout ou la suppression d'audioclip pendant le menu pause, mais c'est normalement inutile.
/// </summary>
public class PauseMenu2 : MonoBehaviour
{
    public bool isPaused = false; // booléen utilisé dans les scripts qui ne s'activent qu'à certains moments
    public List<AudioSource> audiolist;  //contient les audiosource associées aux audioclips en train de jouer
    public List<float> slidervalue;  //sauvegarde les valeurs des volumes entre deux activations du menu pause
    private int nbrSliderBouton;  //sert pour l'affichage, pour bien placer les boutons
    public Slider slide; // slider de référence qui est en dehors de la scène que l'on va copier à chaque fois qu'on crée un nouveau slider
    public Canvas canva; // canva servant pour l'interface graphique, à savoir les sliders et les boutons
    public int nbaudio, nbslider;
    private void OnGUI()
    {

        if (isPaused)
        {
            if (GUI.Button(new Rect(Screen.width - 150, 15, 130, 35), "Continuer")) //on repasse en menu normal et on conserve dans slidervalue les valeurs des volumes des objets, on supprime les sliders
            {
                isPaused = false;
                slidervalue = new List<float>();
                
                for (int i = 0; i < audiolist.Count; i++)  //on casse tout: on supprime tous les sliders
                {
                    if (GameObject.Find(i.ToString()) != null)
                    {
                        Slider slidi = GameObject.Find(i.ToString()).GetComponent<Slider>();
                        slidervalue.Add(slidi.value);
                        Destroy(GameObject.Find(i.ToString()));
                    }
                }
            }


            for (int i = 0; i < audiolist.Count; i++)  //tant qu'on est en pause, on a les boutons avec les noms des chansons
            {
                CreerBouton(i);
            }
            
            Mute();  //on ajoute les boutons Mute et Demute
            Demute();
        }


        else
        {
            if (GUI.Button(new Rect(Screen.width - 150, 15, 130, 35), "Pause"))  //apparition du bouton qui permet de mettre en pause
            {
                isPaused = true;
                nbslider = slidervalue.Count;   
                for (int i = 0; i < nbslider; i++)  //on crée un slider pour chaque audio en train de jouer
                {
                    Slider slidi = CreerSlider(i);
                    slidi.value = slidervalue[i];     //on récupère la valeur qu'on a stocké dans slidervalue
                    slidi.gameObject.name = i.ToString();  // on lui donne un nom qui correspond  à son numéro, pour pouvoir y accéder (notamment le détruire ou accéder à sa valeur)
                }
                for (int i = slidervalue.Count; i < audiolist.Count; i++) // slidervalue ne sera pas toujours de la même taille, cette ligne prévient les erreurs et permet d'ajouter ed nouvelles musiques
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


    public void Update()  //il va servir à garder à jour la liste des audios et à gérer les volumes
    {
        GetList();  //garde la liste d'audios à jour
        nbaudio = audiolist.Count;
        nbrSliderBouton = ((Screen.height - 80) / 35);
        
        for (int i = 0; i < audiolist.Count; i++) //on récupère les valeurs des sliders pour metttre le bon volume sur les musiques
        {
            if (GameObject.Find(i.ToString()) != null)
            {
                Slider slidi = GameObject.Find(i.ToString()).GetComponent<Slider>();
                audiolist[i].volume = slidi.value;
            }
        }

    }


    public void GetList()   // la fonction qui va permettre de choper la liste des Audio qui se jouent 
    {
        AudioSource[] getAudio;
        getAudio = Object.FindObjectsOfType(typeof(AudioSource)) as AudioSource[];  // on prend toutes les audiosource
        audiolist = new List<AudioSource>();
        for (int i = getAudio.Length-1; i >=0 ; i--) //on parcourt en sens inverse car sinon les derniers s'ajoutent au début, et c'est gênant pour récupérer les bonnes slider values
        {
            if (getAudio[i].isPlaying)
            {
                audiolist.Add(getAudio[i]);
            }
        }
    }

    public void CreerBouton(int i) //crée un bouton avec une position cohérente sur l'écran, ce bouton contient le nom de la musique en train de jouer et est en face du slider correspondant
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

    public Slider CreerSlider(int i)  //instancie un slider avec une position cohérente sur l'écran, le slider gère le volume de la musique qui lui est associée.
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


    public void Mute()  // fonction mettant tous les volumes à zero
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

    public void Demute()  //fonction mettant tous les volumes à 1
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

