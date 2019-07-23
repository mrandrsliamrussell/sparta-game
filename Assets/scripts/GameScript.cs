using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    public GameObject piece;
    public GameObject boardpiece;
    public GameObject[,] boardarray = new GameObject[11, 11];
    public List<GameObject> pieceList = new List<GameObject>();
    public GameObject p1UI, p2UI;
    public int turnsTaken;
    // Start is called before the first frame update
    void Start()
    {

        CreateBoard();

        ResetGamePieces();
    }
    void ResetGamePieces()
    {
        for (int i = 0; i < 11; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                switch (i)
                {
                    case 0:
                        InstantiateGamePiece(i, j, 1);
                        break;
                    case 1:
                        InstantiateGamePiece(i, j, 1);
                        break;
                    case 9:
                        InstantiateGamePiece(i, j, 0);
                        break;
                    case 10:
                        InstantiateGamePiece(i, j, 0);
                        break;

                    default:
                        break;

                }
            }
        }
    }
    void RefreshPositions()
    {
        for(int i = 0; i < 11; i++)
        {
            for(int j = 0; j<11; j++)
            {

            }
        }
    }
    void InstantiateGamePiece(int x, int y, int team)
    {
        GameObject newPiece = Instantiate(piece) as GameObject;
        
        newPiece.transform.position = new Vector3(x * boardpiece.GetComponent<Collider>().bounds.size.x, 0.5f, y * boardpiece.GetComponent<Collider>().bounds.size.z);
        newPiece.GetComponent<PieceScript>().x = x;
        newPiece.GetComponent<PieceScript>().y = y;
        newPiece.GetComponent<PieceScript>().team = team;
        pieceList.Add(newPiece);
    }
    void CreateBoard()
    {
        for (int i = 0; i < 11; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                GameObject newBoardPiece = Instantiate(boardpiece) as GameObject;
                newBoardPiece.transform.position =
                    new Vector3(i * boardpiece.GetComponent<Collider>().bounds.size.x, 0,
                    j * boardpiece.GetComponent<Collider>().bounds.size.z);
                newBoardPiece.GetComponent<BoardPieceScript>().x = i;
                newBoardPiece.GetComponent<BoardPieceScript>().y = j;
                
                boardarray[i, j] = newBoardPiece;
                boardarray[i, j].GetComponent<BoardPieceScript>().gameHolder = this.gameObject;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(BoardPieceScript.GlobalTurn == 0)
        {
            p1UI.SetActive(true);
            p2UI.SetActive(false);
        }
        else
        {
            p1UI.SetActive(false);
            p2UI.SetActive(true);
        }
    }

  
   
}
public static class Piece
{

    public static void extend(this GameObject g){



    }
}