using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBase : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject baseCreateButton;

    bool block = false;
    
    private void Update()
    {
        if (Input.GetButton("Fire1") || Input.GetButton("Fire2") || Input.GetButton("Fire3") || Input.GetKeyDown("space"))
        {
            if (player.GetComponent<Points>().LifePoints >= 5
                && player.GetComponent<Points>().ShieldPoints >= 5
                && player.GetComponent<Points>().SpikePoints >= 5)
                    Create();
        }
    }

    public void Create()
    {
        if(!block)
        {
            player.GetComponent<Points>().ChangePoint("Shield", -5);
            player.GetComponent<Points>().ChangePoint("Spike", -5);
            player.GetComponent<Points>().ChangePoint("Life", -5);
            CheckButton();
            GameObject Obj = (GameObject)Instantiate(Resources.Load("Base"), player.transform.position, player.transform.rotation);
            Vector2 pos = Obj.transform.position;
            pos.x += player.transform.up.x * 8;
            pos.y += player.transform.up.y * 8;
            Obj.transform.position = pos;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Base")
        {
            block = true;
            baseCreateButton.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Base")
        {
            block = false;
            CheckButton();
        }
    }

    public void CheckButton()
    {
        if (block == false)
        {
            if (player.GetComponent<Points>().LifePoints >= 5
                && player.GetComponent<Points>().ShieldPoints >= 5
                && player.GetComponent<Points>().SpikePoints >= 5)
            {
                baseCreateButton.SetActive(true);
            }
        }
    }
}
