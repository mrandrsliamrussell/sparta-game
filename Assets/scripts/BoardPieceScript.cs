using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardPieceScript : MonoBehaviour
{
    public Material deselected, selected;
    public static bool clicked = false, pieceSelected = false;
    public int x, y;
    public GameObject pieceOnMe, gameHolder;
    public static GameObject focusPiece;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Renderer>().material = deselected;
        FindPiece();
    }
    GameObject FindPiece(GameObject g)
    {
        GameObject holder = null;
        for (int i = 0; i < gameHolder.GetComponent<GameScript>().pieceList.Count; i++)
        {
           
            if (g.GetComponent<BoardPieceScript>().x == gameHolder.GetComponent<GameScript>().pieceList[i].GetComponent<PieceScript>().x
            && g.GetComponent<BoardPieceScript>().y == gameHolder.GetComponent<GameScript>().pieceList[i].GetComponent<PieceScript>().y)
            {
                pieceOnMe = gameHolder.GetComponent<GameScript>().pieceList[i];
                holder = pieceOnMe;

                return holder;
            }          
        }
        return holder;
    }
    void FindPiece()
    {
        for(int i=0; i< gameHolder.GetComponent<GameScript>().pieceList.Count; i++)
        {
            
            if(this.x == gameHolder.GetComponent<GameScript>().pieceList[i].GetComponent<PieceScript>().x 
            && this.y == gameHolder.GetComponent<GameScript>().pieceList[i].GetComponent<PieceScript>().y)
            {
                pieceOnMe = gameHolder.GetComponent<GameScript>().pieceList[i];
                pieceSelected = true;
                Debug.Log("piece selected");
                break;
            }
            else
            {
                pieceSelected = false;
                
                Debug.Log("piece not selected");
            }
            
        }
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
       
        if (clicked == false)
        {
            clicked = true;
            this.gameObject.GetComponent<Renderer>().material = selected;
            focusPiece = FindPiece(this.gameObject);
            focusPiece.gameObject.GetComponent<Renderer>().material = selected;
            pieceSelected = true;
        }
        else
        {
            if (pieceSelected == true)
            {
                focusPiece.transform.position = new Vector3(x * gameHolder.GetComponent<GameScript>().boardpiece.GetComponent<Collider>().bounds.size.x, 0.5f, y * gameHolder.GetComponent<GameScript>().boardpiece.GetComponent<Collider>().bounds.size.z);
                pieceSelected = false;
                
            }
            clicked = false;
            this.gameObject.GetComponent<Renderer>().material = deselected;
            focusPiece.gameObject.GetComponent<Renderer>().material = deselected;
            pieceSelected = false;
        }
       

    }
}
