using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    public GameObject piece;
    public GameObject boardpiece;
    public GameObject bombH, bombV, bombRad;
    public static int turnsTaken, boardSize = 7;
    public GameObject[,] boardarray = new GameObject[boardSize, boardSize];
    public List<GameObject> pieceList = new List<GameObject>();
    public GameObject p1UI, p2UI, p1Win, p2Win;
    public Text TimeTaken;
    public static bool Winner;
    bool foundObject, hasWon;
 

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {

        CreateBoard();

        ResetGamePieces();
    }
    void ResetGamePieces()
    {
        for (int i = 0; i < boardSize; i++)
        {
            for (int j = 0; j < boardSize; j++)
            {
                switch (i)
                {
                    case 0:
                        InstantiateGamePiece(i, j, 1);
                        break;
                    case 1:
                        InstantiateGamePiece(i, j, 1);
                        break;
                    case 5:
                        InstantiateGamePiece(i, j, 0);
                        break;
                    case 6:
                        InstantiateGamePiece(i, j, 0);
                        break;

                    default:
                        break;

                }
            }
        }
    }
    public void PlaceBombss()
    {
        for(int i = 0; i < boardSize; i++)
        {
            for(int j = 0; j< boardSize; j++)
            {
                
                
                if(Random.Range(0,100) > 96)
                {
                    bool nospawn = false;
                    for(int k =0; k< pieceList.Count; k++)
                    {
                        if(pieceList[k] != null && pieceList[k].GetComponent<PieceScript>().x == i && pieceList[k].GetComponent<PieceScript>().y == j)
                        {
                            nospawn = true;
                        }
                    }
                    switch(j % 3)
                    {
                        case 0:
                            if(nospawn == false) {
                                GameObject newBombRad = Instantiate(bombRad) as GameObject;
                                newBombRad.transform.position = new Vector3(i * boardpiece.GetComponent<Collider>().bounds.size.x, 0.8f,
                                    j * boardpiece.GetComponent<Collider>().bounds.size.z);
                            }
                            
                            break;
                        case 1:
                            if (nospawn == false)
                            {
                                GameObject newBombH = Instantiate(bombH) as GameObject;
                                newBombH.transform.position = new Vector3(i * boardpiece.GetComponent<Collider>().bounds.size.x, 0.8f,
                                   j * boardpiece.GetComponent<Collider>().bounds.size.z);
                            }
                            break;
                        case 2:
                            if (nospawn == false)
                            {
                                GameObject newBombV = Instantiate(bombV) as GameObject;
                                newBombV.transform.position = new Vector3(i * boardpiece.GetComponent<Collider>().bounds.size.x, 0.8f,
                                   j * boardpiece.GetComponent<Collider>().bounds.size.z);
                            }
                            break;
                    }
                    
                    
                   
                }
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
        for (int i = 0; i < boardSize; i++)
        {
            for (int j = 0; j < boardSize; j++)
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

        TimeTaken.text = $"Time  {Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString()} Turn {turnsTaken}";
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

        if(hasWon == false)
        {
            CheckWin();
        }
        
    }

  public void CheckWin()
    {
        int p1count=0, p2count=0;
        for(int i = 0; i < pieceList.Count; i++)
        {
            if (pieceList[i] != null )
            {
                if(pieceList[i].GetComponent<PieceScript>().team == 0)
                {
                    p1count++;
                  
                }               
                else if( pieceList[i].GetComponent<PieceScript>().team == 1)
                {
                    p2count++;
                   
                }
                
            }
        }
        if (p1count == 0)
        {
            Debug.Log("p1 wins");
            p1Win.SetActive(true);
            hasWon = true;
            UIscript.SaveWinner(UIscript.p1text, Mathf.RoundToInt( turnsTaken + (0.1f* Time.timeSinceLevelLoad)));
        }
        else if (p2count == 0)
        {
            Debug.Log("p2 wins");
            p2Win.SetActive(true);
            hasWon = true;
            UIscript.SaveWinner(UIscript.p2text, turnsTaken);

        }
        Debug.Log(UIscript.p1text);
        Debug.Log(UIscript.p2text);
    }
   
      
    
   
}
