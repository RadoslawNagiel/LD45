using UnityEngine;
using System.Collections;

public class DamageTaking : MonoBehaviour
{
    [SerializeField] int hp = 1;

    public virtual void TakeDamage(int damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
