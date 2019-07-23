using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PieceScript : MonoBehaviour
{
    public int team;
    public int x, y;
    public GameObject boardpiece, gameHolder;
    public Material selected, deselected;
    // Start is called before the first frame update

   
    void Start()
    {
        
        //set allowed moves

    }

    // Update is called once per frame
    void Update()
    {
        boardpiece = gameHolder.GetComponent<GameScript>().boardarray[x, y];
    }
}
