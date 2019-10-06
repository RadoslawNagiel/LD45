using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject[] ToDelite;
    [SerializeField] GameObject[] AnimatorsGameobjects;
    [SerializeField] string[] AnimationsNames;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            foreach (GameObject item in ToDelite)
            {
                Destroy(item);
            }
            for (int i = 0; i < AnimatorsGameobjects.Length; i++)
            {
                AnimatorsGameobjects[i].GetComponent<Animator>().Play(AnimationsNames[i]);
            }
        }
    }
}
