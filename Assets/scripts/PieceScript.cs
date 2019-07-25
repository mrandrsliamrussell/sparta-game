using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PieceScript : MonoBehaviour
{
    public int team;
    public int x, y;
    public GameObject boardpiece, gameHolder;
    public Material deselected, selected, deselected2;
    public static bool clicked = false, pieceSelected = false;
    public GameObject pieceOnMe;
    public static GameObject focusPiece;
    public static int GlobalTurn;
    // Start is called before the first frame update


    void Start()
    {
        if (team == 0)
        {
            this.gameObject.GetComponent<Renderer>().material = deselected;
        }
        else
        {
            this.gameObject.GetComponent<Renderer>().material = deselected2;
        }
        //set allowed moves

    }

    // Update is called once per frame
   
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.GetComponent<PieceScript>() != null)
        {
            if(BoardPieceScript.GlobalTurn == col.gameObject.GetComponent<PieceScript>().team)
            {
                
                Destroy(this.gameObject);
            }
        }
    }
    void OnMouseExit()
    {
        if (clicked == false)
        {
            if (team == 0)
            {
                this.gameObject.GetComponent<Renderer>().material = deselected;
            }
            else
            {
                this.gameObject.GetComponent<Renderer>().material = deselected2;
            }
            
        }

    }

    void OnMouseOver()
    {
        if (clicked == false)
        {
            this.gameObject.GetComponent<Renderer>().material = selected;
        }

    }
    void OnMouseDown()
    {

        if (clicked == false)
        {
            clicked = true;
            this.gameObject.GetComponent<Renderer>().material = selected;
            
            pieceSelected = true;
        }
        else
        {
            if (pieceSelected == true)
            {
                this.transform.position = new Vector3(focusPiece.GetComponent<BoardPieceScript>().x * gameHolder.GetComponent<GameScript>().boardpiece.GetComponent<Collider>().bounds.size.x, 0.5f,
                    focusPiece.GetComponent<BoardPieceScript>().y * gameHolder.GetComponent<GameScript>().boardpiece.GetComponent<Collider>().bounds.size.z);
                pieceSelected = false;
              
                
                if (BoardPieceScript.GlobalTurn == 0)
                {
                    BoardPieceScript.GlobalTurn = 1;
                    GameScript.turnsTaken++;
                }
                else
                {
                    BoardPieceScript.GlobalTurn = 0;
                    GameScript.turnsTaken++;
                }
                
            }
            clicked = false;
            if (team == 0)
            {
                this.gameObject.GetComponent<Renderer>().material = deselected;
            }
            else
            {
                this.gameObject.GetComponent<Renderer>().material = deselected2;
            }

            pieceSelected = false;
        }


    }
}
