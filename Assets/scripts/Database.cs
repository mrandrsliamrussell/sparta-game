using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using UnityEngine;

public class Database : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
     
      using(var db = new game_databaseEntities())
        {
            
        }
      using(var db = new NorthwindEntities())
        {
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
