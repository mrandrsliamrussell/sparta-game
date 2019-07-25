using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.GetComponent<PieceScript>())
        {
            Destroy(col.gameObject, 1f);
        }
        if (col.gameObject.GetComponent<Bomb>())
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = true;
        }

    }
}
