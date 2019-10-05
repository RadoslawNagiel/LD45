using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    [SerializeField] bool ShieldPoints, LifePoints, SpikePoints;
    [SerializeField] int[] PointsToUnlock;
    [SerializeField] GameObject[] ObjectToUnlock;

    int lvl;
    int points;

    private void Start()
    {
        lvl = 0;
        points = 0;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {

        }
        if(points >= PointsToUnlock[lvl])
        {
            foreach (GameObject item in ObjectToUnlock)
            {
                item.SetActive(true);
            }
            lvl ++;
            points = 0;
            if (lvl > PointsToUnlock.Length)
                enabled = false;
        }
    }
}
