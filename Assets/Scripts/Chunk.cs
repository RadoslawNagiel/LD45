using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    GameObject[] AdjacentChunks = new GameObject[8];
    public GameObject[] CheckPoints = new GameObject[8];

    [SerializeField] int MaxItems;
    [SerializeField] int PointChanse;
    [SerializeField] int ItemChanse;
    [SerializeField] float maxDelay;
    float Delay;

    public List<GameObject> ItemList = new List<GameObject>();


    bool enough;

    private void Start()
    {
        enough = false;
        checkAdjacent();
        Delay = Random.Range(0, maxDelay);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if(!enough && collision.tag == "Chunk")
        {
            checkAdjacent();
        }
        if (collision.tag == "Player")
        {
            if (!enough)
            {
                for (int i = 0; i <= 7; i++)
                {
                    if (AdjacentChunks[i] == null)
                    {
                        GameObject Obj = (GameObject)Instantiate(Resources.Load("Chunk"), transform.position, transform.rotation, transform.parent);

                        Vector2 pos = Obj.transform.position;

                        switch (i)
                        {
                            case 0:
                                pos.x -= 64;
                                pos.y += 64;
                                break;
                            case 1:
                                pos.y += 64;
                                break;
                            case 2:
                                pos.y += 64;
                                pos.x += 64;
                                break;
                            case 3:
                                pos.x -= 64;
                                break;
                            case 4:
                                pos.x += 64;
                                break;
                            case 5:
                                pos.x -= 64;
                                pos.y -= 64;
                                break;
                            case 6:
                                pos.y -= 64;
                                break;
                            case 7:
                                pos.y -= 64;
                                pos.x += 64;
                                break;
                        }
                        Obj.transform.position = pos;

                        AdjacentChunks[i] = Obj;
                    }
                }
                checkAdjacent();
                for (int i = 0; i < 8; i++)
                {
                    AdjacentChunks[i].GetComponent<Chunk>().checkAdjacent();
                }
            }
            GenerateItems();
            for (int i = 0; i <= 7; i++)
            {
                AdjacentChunks[i].GetComponent<Chunk>().GenerateItems();
            }
        }
    }

    public void GenerateItems()
    {
        if(ItemList.Count >= MaxItems)
        {
            for (int i = 0; i < ItemList.Count; i++)
            {
                if (ItemList[i] == null)
                {
                    ItemList.RemoveAt(i);
                }
            }
        }
        if (Delay > 0)
            Delay -= Time.deltaTime;
        else if(ItemList.Count < MaxItems)
        {
            float rnd = Random.Range(0, ItemChanse + PointChanse);
            int i = Random.Range(1, 4);
            
            string name ="";
            if (rnd < ItemChanse)
            {
                switch(i)
                {
                    case 1:
                        name = "Life";
                        break;
                    case 2:
                        name = "Shield";
                        break;
                    case 3:
                        name = "Spike";
                        break;
                }
            }
            else
            {
                switch (i)
                {
                    case 1:
                        name = "LifePoint";
                        break;
                    case 2:
                        name = "ShieldPoint";
                        break;
                    case 3:
                        name = "SpikePoint";
                        break;
                }
            }
            GameObject Obj = (GameObject)Instantiate(Resources.Load(name), transform.position, transform.rotation);
            ItemList.Add(Obj);
            Vector2 pos = Obj.transform.position;
            pos.x += Random.Range(-32, 32);
            pos.y += Random.Range(-32, 32);
            Obj.transform.position = pos;
            Delay = Random.Range(0, maxDelay);
        }
    }

    public void checkAdjacent()
    {
        for (int i = 0; i < 8; i++)
        {
            if(AdjacentChunks[i] == null && CheckPoints[i].GetComponent<ChunkCheckCollision>().Coll != null)
            {
                AdjacentChunks[i] = CheckPoints[i].GetComponent<ChunkCheckCollision>().Coll;
                Destroy(CheckPoints[i].gameObject); 
            }
            else if(AdjacentChunks[i] != null)
            {
                Destroy(CheckPoints[i].gameObject);
            }
        }
        int x = 0;
        for (int i = 0; i < 8; i++)
        {
            if (AdjacentChunks[i] != null)
                x++;
        }
        if (x == 8)
        {
            enough = true;
        }
    }
}
