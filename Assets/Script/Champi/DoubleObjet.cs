using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleObjet : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        GameObject[] listGameObject =  GameObject.FindGameObjectsWithTag("ObjectParent");
        int i = 0;
        foreach(GameObject item in listGameObject)
        {
            if (i > 0)
            {
                Destroy(listGameObject[i]);
            }
            i += 1;
        }
    }
}
