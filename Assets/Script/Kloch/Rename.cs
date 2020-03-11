using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
