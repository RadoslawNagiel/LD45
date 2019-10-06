using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModulesAttach : MonoBehaviour
{
    private bool IsAttachedToPlayer;

    void OnTriggerEnter2D(Collider2D collision)
    {

        ModulesAttach module = collision.gameObject.GetComponent<ModulesAttach>();
        if (IsAttachedToPlayer || !isPlayerModule(module) && !isPlayerDot(collision.gameObject))
            return;

        gameObject.transform.SetParent(collision.gameObject.transform);

        IsAttachedToPlayer = true;
        onAttach(collision);
    }

    protected virtual void onAttach(Collider2D collision) {}

    private bool isPlayerModule(ModulesAttach module) => module?.IsAttachedToPlayer ?? false;

    private bool isPlayerDot(GameObject obj) => obj.GetComponent<DotMovement>() != null;
}
