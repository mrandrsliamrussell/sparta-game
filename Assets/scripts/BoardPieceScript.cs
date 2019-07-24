using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardPieceScript : MonoBehaviour
{
    public Material deselected, selected;
    public static bool clicked = false;
    public int x, y;
    public GameObject pieceOnMe, gameHolder;
    
    public static int GlobalTurn;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Renderer>().material = deselected;
        
    }
  

    // Update is called once per frame
    void OnMouseExit()
    {
        if(clicked == false)
        {
            this.gameObject.GetComponent<Renderer>().material = deselected;
        }
        
    }
    
    void OnMouseOver()
    {
        if(clicked == false)
        {         
            this.gameObject.GetComponent<Renderer>().material = selected;
        }
       
    }
    void OnMouseDown()
    {
        if(PieceScript.pieceSelected == true) {


            PieceScript.focusPiece = this.gameObject;
        }
        else
        {
            PieceScript.focusPiece = null;
        }
    }
  
}
