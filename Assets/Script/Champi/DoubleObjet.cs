using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Si un objet existe déjà, on le supprime.
// Ce script a été écrit car quand on retourne sur la scène d'Introduction
// Les gameObject sont ré-instanciés (donc 2 fois le même GameObject).

public class DoubleObjet : MonoBehaviour
{
    void Update()
    {
        GameObject[] listGameObject =  GameObject.FindGameObjectsWithTag("ObjectParent");
        int i = 0;
        foreach(GameObject item in listGameObject)
        {
            // Si l'objet existe plus d'une fois alors on supprime toutes les copies supllémentaires.
            if (i > 0)
            {
                Destroy(listGameObject[i]);
            }
            i += 1;
        }
    }
}
