using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    [SerializeField] GameObject SpikeText, LifeText, ShieldText;
    int SpikePoints, LifePoints, ShieldPoints;

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
            ShieldPoints++;
            ShieldText.GetComponent<Text>().text = ShieldPoints.ToString();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Spike")
        {
            SpikePoints++;
            SpikeText.GetComponent<Text>().text = SpikePoints.ToString();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Life")
        {
            LifePoints++;
            LifeText.GetComponent<Text>().text = LifePoints.ToString();
            Destroy(collision.gameObject);
        }
    }
}
