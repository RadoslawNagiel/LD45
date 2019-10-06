using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkCheckCollision : MonoBehaviour
{
    public GameObject Coll;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Chunk")
            Coll = collision.gameObject;
    }
}
