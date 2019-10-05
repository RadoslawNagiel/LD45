using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    [SerializeField] bool NeedShieldPoints, NeedLifePoints, NeedSpikePoints;
    [SerializeField] int[] PointsToUnlock;
    [SerializeField] GameObject[] ObjectToUnlock;
    [SerializeField] GameObject load;

    int lvl;
    int points;
    int ShieldPoints, LifePoints, SpikePoints;

    private void Start()
    {
        lvl = 0;
        points = 0;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (lvl < PointsToUnlock.Length)
        {
            if (collision.gameObject.tag == "Player")
            {
                ShieldPoints = collision.gameObject.GetComponent<Points>().ShieldPoints;
                LifePoints = collision.gameObject.GetComponent<Points>().LifePoints;
                SpikePoints = collision.gameObject.GetComponent<Points>().SpikePoints;
                if (NeedShieldPoints || NeedLifePoints || NeedSpikePoints)
                {
                    if (((NeedShieldPoints && NeedLifePoints && NeedSpikePoints && 
                        ShieldPoints >= LifePoints && ShieldPoints >= SpikePoints) ||
                            (NeedShieldPoints && !NeedLifePoints && !NeedSpikePoints)) && ShieldPoints > 0)
                    {
                        collision.gameObject.GetComponent<Points>().ChangePoint("Shield", -1);
                        ShieldPoints--;
                        points++;
                    }
                    else if (((NeedShieldPoints && NeedLifePoints && NeedSpikePoints &&
                        SpikePoints >= LifePoints) ||
                            (!NeedShieldPoints && !NeedLifePoints && NeedSpikePoints)) && SpikePoints > 0)
                    {
                        collision.gameObject.GetComponent<Points>().ChangePoint("Spike", -1);
                        SpikePoints--;
                        points++;
                    }
                    else if (((NeedShieldPoints && NeedLifePoints && NeedSpikePoints) ||
                            (!NeedShieldPoints && NeedLifePoints && !NeedSpikePoints)) && LifePoints > 0)
                    {
                        collision.gameObject.GetComponent<Points>().ChangePoint("Life", -1);
                        LifePoints--;
                        points++;
                    }
                }
            }
            load.GetComponent<StatusBar>().SetBar(1f * points / PointsToUnlock[lvl]);
            if (points >= PointsToUnlock[lvl])
            {
                foreach (GameObject item in ObjectToUnlock)
                {
                    item.SetActive(true);
                }
                lvl++;
                points = 0;
            }
        }
        
    }
}
