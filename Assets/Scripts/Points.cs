using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    [SerializeField] GameObject SpikeText, LifeText, ShieldText;
    [SerializeField] GameObject TextCanvas;
    [SerializeField] GameObject BaseCreator;
    public int SpikePoints, LifePoints, ShieldPoints;

    private void Start()
    {
        SpikePoints = 0;
        LifePoints = 0;
        ShieldPoints = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   
        if(collision.gameObject.tag == "Shield")
        {
            ChangePoint("Shield", 1);
            Destroy(collision.gameObject);
            GetComponent<AudioSource>().Play();
        }
        else if (collision.gameObject.tag == "Spike")
        {
            ChangePoint("Spike", 1);
            Destroy(collision.gameObject);
            GetComponent<AudioSource>().Play();
        }
        else if (collision.gameObject.tag == "Life")
        {
            ChangePoint("Life", 1);
            Destroy(collision.gameObject);
            GetComponent<AudioSource>().Play();
        }
    }

    public void ChangePoint(string name, int value)
    {
        if (!TextCanvas.activeSelf)
        {
            GetComponent<Animator>().Play("CanvasAnimation");
        }

        switch (name)
        {
            case "Shield":
                ShieldPoints += value;
                ShieldText.GetComponent<Text>().text = ShieldPoints.ToString();
                break;
            case "Spike":
                SpikePoints += value;
                SpikeText.GetComponent<Text>().text = SpikePoints.ToString();
                break;
            case "Life":
                LifePoints += value;
                LifeText.GetComponent<Text>().text = LifePoints.ToString();
                break;
        }
        BaseCreator.GetComponent<CreateBase>().CheckButton();
    }
}
