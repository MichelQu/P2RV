using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangementScene : MonoBehaviour
{
    private GameObject selected;

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
}

