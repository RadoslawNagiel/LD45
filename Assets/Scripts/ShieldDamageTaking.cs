using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldDamageTaking : DamageTaking
{
    [SerializeField] Sprite[] shieldSprites;

    private SpriteRenderer renderer;

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        renderer.sprite = shieldSprites[hp];
    }
}
