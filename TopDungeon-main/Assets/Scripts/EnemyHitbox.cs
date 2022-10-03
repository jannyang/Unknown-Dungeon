using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : Collidable
{
    #region Fields
    public int damage = 1;
    public float pushForce = 5;
    #endregion

    #region Methods
    protected override void OnCollide(Collider2D coli)
    {
        if (coli.tag == "Fighter" && coli.name == "Player")
        {
            //�÷��̾ ������ ������ ��

            Damage dmg = new Damage()
            {
                damageAmount = damage,
                origin = transform.position,
                pushForce = pushForce
            };

            coli.SendMessage("ReceiveDamage", dmg);
        }
    }
    #endregion
}
