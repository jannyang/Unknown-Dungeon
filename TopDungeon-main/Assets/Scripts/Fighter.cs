using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    #region Fields
    public int hitpoint = 10;
    public int maxHitpoint = 10;
    public float pushRecoverySpeed = 0.2f;

    // �鿪�ð�
    protected float immuneTime = 1.0f;
    protected float lastImmune;

    protected Vector3 pushDirection;
    #endregion

    #region Methods
    
    protected virtual void ReceiveDamage(Damage dmg)
    {
        // ������ ���� �� ���� �ð��� ������ �ٽ� ������ ����
        if (Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;
            hitpoint -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce; // �ǰ� �� �и�

            GameManager.instance.ShowText(dmg.damageAmount.ToString(), 25, Color.red, transform.position, Vector3.zero, 0.5f); // ���ط� �ؽ�Ʈ ����

            if (hitpoint <= 0) // HP�� 0������ �� ���
            {
                hitpoint = 0;
                Death();
            }
        }
    }

    protected virtual void Death()
    {

    }
    #endregion


}