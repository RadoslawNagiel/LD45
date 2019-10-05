using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
    [SerializeField] int cost = 5;
    [SerializeField] GameObject load;
    [SerializeField] string resourcesName;

    int moneyInput;
    float delay;
    bool full; 
    
    private void Start()
    {
        moneyInput = 0;
        delay = 0;
        full = false;
        Vector2 scale = load.transform.localScale;
        Vector2 pos = load.transform.localPosition;
        scale.x = 0;
        pos.x = -0.5f;
        load.transform.localScale = scale;
        load.transform.localPosition = pos;
    }

    void Update()
    {
        if(full)
        {
            delay -= Time.deltaTime;
            Vector2 sc = load.transform.localScale;
            Vector2 pos = load.transform.localPosition;
            sc.x = 1f * delay / cost;
            pos.x = -((1f * cost - delay) / cost) / 2f;
            load.transform.localScale = sc;
            load.transform.localPosition = pos;
            if (delay <= 0)
            {
                full = false;
                delay = 0;
                CreateObject();
            }
        }
        else if (delay > 0)
            delay -= Time.deltaTime;
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!full && delay <= 0 && collision.tag == "Player")
        {
            moneyInput++;
            load.GetComponent<StatusBar>().SetBar(1f * moneyInput / cost);

            delay = 1f;
            if (moneyInput == cost)
            {
                moneyInput = 0;
                full = true;
                delay = cost;
            }
        }
    }

    private void CreateObject()
    {
        GameObject Obj = (GameObject)Instantiate(Resources.Load(resourcesName), transform.position, transform.rotation, transform);
        Vector3 pos = Vector3.zero;
        pos.y += 3;
        Obj.transform.localPosition = pos;
        Obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(200, 0));
    }
}
