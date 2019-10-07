using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Marker : MonoBehaviour
{
    public Transform baseGameobject;
    public Transform player;

    Vector2 startPos;

    private void Start()
    {
        startPos = GetComponent<RectTransform>().anchoredPosition;
    }

    private void Update()
    {
        Vector2 vector = baseGameobject.position - player.position;
        if(Vector2.Distance(baseGameobject.position, player.position ) < 30)
        {
            GetComponent<RawImage>().enabled = false;
        }
        else
        {
            GetComponent<RawImage>().enabled = true;
            vector.Normalize();
            if (vector.x != 0)
            {
                float mix = (Screen.height / 2f) / vector.y;
                if (vector.y < 0)
                    mix = -mix;
                vector *= mix;
                if (Mathf.Abs(vector.x) > Screen.width / 2f)
                {
                    mix = (Screen.width / 2) / vector.x;
                    if (vector.x < 0)
                        mix = -mix;
                    vector *= mix;
                }
            }
            else
            {
                vector *= Screen.height / 2;
            }

            Vector2 pos = startPos + vector;
            GetComponent<RectTransform>().anchoredPosition = vector;
        }
    }
}
