using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneConfiguration3 : MonoBehaviour
{
    public Object[] audioclip;
    private int nbrWidth;
    private int resteWidth;
    private int nbrHeight;
    private int hauteurBase = 90;
    private int ecartLong;
    private int longueurBase;

    private int nbrBouton;

    public int numPage = 0;

    private void Start()
    {
        audioclip = Resources.LoadAll("Audio", typeof(AudioClip));
    }

    private void Update()
    {
        nbrWidth = Screen.width / 180; // Le nombre de bouton en long
        resteWidth = (Screen.width % 180); // Le nombre de pixel restant en long
        longueurBase = resteWidth / (nbrWidth + 1);
        ecartLong = (resteWidth / (nbrWidth + 1)) + 180; // Ecart entre 2 boutons sur la longueur
        nbrHeight = ((Screen.height - 90) / 40) - 1; // Le nombre de bouton en hauteur
        // Le nombre de bouton sur une page est de :
        nbrBouton = nbrHeight * nbrWidth;
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width - 150, 15, 130, 35), "Choix de l'Objet"))
        {
            SceneManager.LoadScene("Configuration2");
        }

        int i = 0;

        // Gère les pages
        if (numPage > 1)
        {
            if (GUI.Button(new Rect(15, Screen.height - 45, 150, 30), "Page précédente"))
            {
                numPage -= 1;
            }
        }

        if (audioclip.Length - numPage * nbrBouton > 0)
        {
            if (GUI.Button(new Rect(Screen.width - 175, Screen.height - 45, 150, 30), "Page suivante"))
            {
                numPage += 1;
            }
        }

        foreach (AudioClip item in audioclip)
        {
            // On incrémente la variable i
            i += 1;

            // On sélectionne seulement les audiclips qui doivent s'afficher sur la page.
            if (i <= nbrBouton * numPage && i > nbrBouton * (numPage - 1))
            {
                // Si on appuie sur une des musiques.
                if (GUI.Button(new Rect(longueurBase, hauteurBase, 180, 30), item.name))
                {
                    // Récupérer le gameObject attaché au QRCode
                    // Changer la musique avec celui choisi
                    // Retour à la scène Configuration
                    SceneManager.LoadScene("Configuration");
                }

                // On place un bouton en dessous
                hauteurBase += 40;

                if (i % nbrHeight == 0)
                {
                    // On change de colonne
                    hauteurBase = 90;
                    longueurBase += ecartLong;
                }
            }
        }

        // On réinitialise les valeurs
        hauteurBase = 90;
        longueurBase = resteWidth / (nbrWidth + 1);
    }
}
