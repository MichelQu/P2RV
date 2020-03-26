using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// script attaché aux objets pour leur donner le nom de l'audioclip attaché: on s'en sert pendant la pause pour savoir de quoi on modifie le son
/// </summary>
public class Rename : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        if (this.GetComponent<AudioSource>().clip != null) 
        { 
            this.name = this.GetComponent<AudioSource>().clip.name;
        }
    }
    
}
