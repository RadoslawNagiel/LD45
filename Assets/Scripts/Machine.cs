using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
    [SerializeField] bool NeedShieldPoints, NeedLifePoints, NeedSpikePoints;
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
        load.GetComponent<StatusBar>().SetBar(0);
    }

    void Update()
    {
        if(full)
        {
            delay -= Time.deltaTime;
            load.GetComponent<StatusBar>().SetBar(1f * delay / cost);
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
            bool Next = false;

            if(NeedShieldPoints && collision.GetComponent<Points>().ShieldPoints > 0)
            {
                collision.GetComponent<Points>().ChangePoint("Shield", -1);
                Next = true;
            }
            else if (NeedSpikePoints && collision.GetComponent<Points>().SpikePoints > 0)
            {
                collision.GetComponent<Points>().ChangePoint("Spike", -1);
                Next = true;
            }
            else if (NeedLifePoints && collision.GetComponent<Points>().LifePoints > 0)
            {
                collision.GetComponent<Points>().ChangePoint("Life", -1);
                Next = true;
            }

            if (Next)
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
    }

    private void CreateObject()
    {
        GameObject Obj = (GameObject)Instantiate(Resources.Load(resourcesName), transform.position, transform.rotation, transform);
        Vector3 pos = Vector3.zero;
        pos.y += 3;
        Obj.transform.localPosition = pos;
        Obj.GetComponent<Rigidbody2D>().AddForce(transform.up * 1000);
        GetComponent<AudioSource>().Play();
    }
}
