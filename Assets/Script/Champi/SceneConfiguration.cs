using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneConfiguration : MonoBehaviour
{
    private GameObject[] listgo;
    private int nbrCase;

    private void Start()
    {
        listgo = GameObject.FindGameObjectsWithTag("Object");
        // Debug.Log("Il y a : " + listgo.Length + " dans la liste.");
    }

    private void Update()
    {
        nbrCase = (Screen.height / 50) - 1;
        // Debug.Log("Il y a : " + nbrCase + " places.");
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width - 150, 15, 130, 35), "Menu Principal"))
        {
            SceneManager.LoadScene("Intro");
        }

        int i = 0;

        foreach(GameObject item in listgo)
        {
            if ( i < nbrCase)
            {
                if (GUI.Button(new Rect(25, 50 + 45*i, 100, 35), item.name))
                {
                    // creerDropdown(item);
                }
            }

            if (i>= nbrCase && i< 2 * nbrCase)
            {
                if (GUI.Button(new Rect(150, 50 + 45 * i, 100, 35), item.name))
                {
                    // creerDropdown(item);
                }
            }

            i += 1;
        }
    }

    //public void creerDropdown(GameObject item)
    //{

    //}
}
