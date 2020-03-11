using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{

    private Vector3 screenPoint;
    private Vector3 offset;
    private GameObject thePlayer;
    private PauseMenu pausemenu;

    private void Start()
    {
        thePlayer = GameObject.Find("Main Camera");
        pausemenu = thePlayer.GetComponent<PauseMenu>();
        
    }

    void Update()
    {

        pausemenu = thePlayer.GetComponent<PauseMenu>();

    }


    void OnMouseDown()
    {
        if ( !(pausemenu.isPaused) ) 
        {
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        }
    }
    
    void OnMouseDrag()
    {
        if (!pausemenu.isPaused)
        {
            Vector3 cursorScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorScreenPoint) + offset;
            transform.position = cursorPosition;
        }
    }

}


