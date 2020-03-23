using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Ce script récupère les gameObjects dans le dossier Prefabs.
// Et il les affiche de façon automatique sur l'écran dans la scène Configuration2.

public class SceneConfiguration2 : MonoBehaviour
{
    public Object[] listPrefabs;
    int nbrCase, nbrLigne, espace, nbrBouton;
    int longueurBase;
    int hauteurBase = 60;
    int taillecase = 120;

    public void Start()
    {
        // On charge tous les prefabs dans le dosier Ressources.
        listPrefabs = Resources.LoadAll("Prefabs", typeof(GameObject));
    }

    public void Update()
    {
        // On calcule les variables qui permettront de bien placés les boutons.
        nbrCase = ((Screen.height - 70) / 50);
        nbrLigne = (Screen.width) / taillecase;
        espace = ((Screen.width) % taillecase) / (nbrLigne + 1);
        nbrBouton = nbrLigne * nbrCase;
        longueurBase = espace;
    }

    private void OnGUI()
    {
        // On crée un bouton qui permet de revenir à la scène Configuration.
        if (GUI.Button(new Rect(Screen.width - 150, 15, 130, 35), "Choix QR Code"))
        {
            SceneManager.LoadScene("Configuration");
        }

        int i = 0;

        // Pour chaque objet dans la listPrefab, on crée un bouton.
        foreach (Object item in listPrefabs)
        {
            i += 1;
            if (i <= nbrBouton)
            {
                if (GUI.Button(new Rect(longueurBase, hauteurBase, taillecase, 45), item.name))
                {
                    // TODO : reste à le configurer.

                    // On récupère le GameObject QRCode lié au nom stocké dans PlayerPrefs (QRName)
                    // GameObject go = GameObject.Find(PlayerPrefs.GetString("QRName"));
                    // Transform pos = go.transform;
                    // On lui ajoute en fils le gameObject selectionné par le bouton
                    // GameObject instance = Instantiate(Resources.Load(item.name, typeof(Object)), pos) as GameObject;
                    // instance.transform.parent = go.transform;
                    // Il reste plus qu'à lui associer un son

                    PlayerPrefs.SetString("ConfigGO", item.name);
                    SceneManager.LoadScene("Configuration3");
                }
                hauteurBase += 50; 
            }

            if (i % nbrCase == 0)
            {
                // On change de colonne
                hauteurBase = 60;
                longueurBase += (espace+ taillecase);
            }
        }

        // On réinitialise les variables.
        hauteurBase = 60;
    }

}
