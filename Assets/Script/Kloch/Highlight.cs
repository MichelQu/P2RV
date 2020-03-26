using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// script qui active un outliner quand la souris passe au-dessus
/// </summary>
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
