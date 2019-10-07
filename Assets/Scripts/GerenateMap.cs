using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenateMap : MonoBehaviour
{
    [SerializeField] GameObject[] Objects;
    [SerializeField] int[] ObjecyGenerateChanse;

    [SerializeField] int MaxItems;
    [SerializeField] float maxDelay;
    float Delay;


    List<GameObject> ItemList = new List<GameObject>();


    private void Update()
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
        else if(Delay > 0 )
        {
            Delay -= Time.deltaTime;
        }
        else
        {
            int chanse = 0;
            foreach (int item in ObjecyGenerateChanse)
            {
                chanse += item;
            }
            int rnd = Random.Range(0, chanse);

            chanse = 0;
            GameObject Obj = null;
            for (int i = 0; i < Objects.Length; i++)
            {
                chanse += ObjecyGenerateChanse[i];
                if (rnd < chanse)
                {
                    Obj = Objects[i];
                    break;
                }
            }
            GameObject InstantiedObj = (GameObject)Instantiate(Obj, transform.position, transform.rotation);

            Vector2 pos = InstantiedObj.transform.position;
            Random.InitState(System.DateTime.Now.Millisecond);
            float r = Random.Range(32f, 50f);
            Vector2 Rnd = Random.insideUnitCircle.normalized * r;
            pos.x += Rnd.x;
            pos.y += Rnd.y;
            InstantiedObj.transform.position = pos;

            ItemList.Add(InstantiedObj);
            Delay = Random.Range(0, maxDelay);
            
        }
    }
}
