using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rename : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.name = this.GetComponent<AudioSource>().clip.name;
    }

}
