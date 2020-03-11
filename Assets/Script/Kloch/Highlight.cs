using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    private void OnMouseOver()
    {
        gameObject.GetComponent<Renderer>().material.shader = Shader.Find("Outlined/highlighter");
    }
    private void OnMouseExit()
    {
        gameObject.GetComponent<Renderer>().material.shader = Shader.Find("Diffuse");

    }
}
