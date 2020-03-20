using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Ce script permet de réaliser le changement de scène pour réaliser un changement de musique.
// Le script s'active seulement si le menu Pause est désactivé.

public class ChangementScene : MonoBehaviour
{
    private GameObject selected;
    private bool isPaused;

    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "SceneP")
        {
            GameObject Cam = GameObject.FindGameObjectWithTag("MainCamera");
            isPaused = Cam.GetComponent<PauseMenu>().isPaused;
            // Debug.Log(isPaused);
        }
    }

    private void OnMouseDown()
    {
        if (!isPaused)
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
}

