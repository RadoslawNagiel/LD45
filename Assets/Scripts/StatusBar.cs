using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusBar : MonoBehaviour
{
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
