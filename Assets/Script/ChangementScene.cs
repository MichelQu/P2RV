using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangementScene : MonoBehaviour
{
    private GameObject selected;
    private Object[] obj;

    public void Start()
    {
        // obj = Resources.LoadAll("Prefabs", typeof(GameObject));
    }

    // TODO à réaliser seulement si on est dans le menu pause du jeu
    // Variable de type booléen à rajouter lors de la fusion du projet

    private void OnMouseDown()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            selected = hit.collider.gameObject;
            PlayerPrefs.SetString("name", selected.name);
            // Debug.Log("Nom de la musique : " + PlayerPrefs.GetString("name"));
            SceneManager.LoadScene("MenuChoix");
           }
    }


    private void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width - 190, 10, 180, 30), "Réinitialisation"))
        {
            // On réattribue les musiques originelles aux gameObjects
            GameObject[] go1 = GameObject.FindGameObjectsWithTag("Object");
            Debug.Log("Nombre d'objets : " + go1.Length);
            foreach (GameObject item in go1)
            {
                // Trouver tous les GO avec le même nom
                string nom = item.name;
                // Chemin
                string chemin = "Prefabs/" + nom;
                // Debug.Log("Chemin :" + chemin);
                // Sauvegarder leur position
                Transform pos = item.transform;
                // Instancier de nouveaux GO au même endroit, avec musique d'origine"
                GameObject instance = Instantiate(Resources.Load(nom, typeof(Object)), pos) as GameObject;
            }

            foreach (GameObject item in go1)
            {
                Destroy(item);
            }

            // On retire toutes les sauvergardes d'ancien choix
            PlayerPrefs.DeleteKey("name");
            PlayerPrefs.DeleteKey("MusicNum");
            PlayerPrefs.DeleteKey("MusicName");
        }
    }

}

