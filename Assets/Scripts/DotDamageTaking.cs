using UnityEngine;
using System.Collections;
using System.Linq;

public class DotDamageTaking : DamageTaking
{
    public override void TakeDamage(int damage)
    {
        var life = gameObject.GetComponentInChildren<Life>();
        if(life == null)
        {
            base.TakeDamage(damage);
        }
    }
}
