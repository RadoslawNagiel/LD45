using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusBar : MonoBehaviour
{
    private void Start()
    {
        Vector2 sc = new Vector2(0, 0);
        Vector2 pos = new Vector2(0, 0);
        transform.localScale = sc;
        transform.localPosition = pos;
    }

    public void SetBar(float x)
    {
        Vector2 sc = transform.localScale;
        Vector2 pos = transform.localPosition;
        sc.x = x;
        pos.x = -(1f - x) / 2f;
        transform.localScale = sc;
        transform.localPosition = pos;
    }
}
