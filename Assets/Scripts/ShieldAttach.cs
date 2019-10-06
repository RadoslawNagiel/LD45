using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldAttach : ModulesAttach
{
    protected override void onAttach(Collider2D collision)
    {
        transform.right = collision.transform.position - transform.position;
        StartCoroutine(moveCloser(collision));
    }

    private IEnumerator moveCloser(Collider2D collision)
    {
        yield return null;
        transform.position += (Vector3) (collision.ClosestPoint(transform.position) -
            gameObject.GetComponent<Collider2D>().ClosestPoint(collision.transform.position));
    }
}
