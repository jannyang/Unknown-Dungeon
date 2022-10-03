using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    #region Fields
    public int hitpoint = 10;
    public int maxHitpoint = 10;
    public float pushRecoverySpeed = 0.2f;

    // 면역시간
    protected float immuneTime = 1.0f;
    protected float lastImmune;

    protected Vector3 pushDirection;
    #endregion

    #region Methods
    
    protected virtual void ReceiveDamage(Damage dmg)
    {
        // 데미지 받은 후 일정 시간이 지나야 다시 데미지 입음
        if (Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;
            hitpoint -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce; // 피격 후 밀림

            GameManager.instance.ShowText(dmg.damageAmount.ToString(), 25, Color.red, transform.position, Vector3.zero, 0.5f); // 피해량 텍스트 노출

            if (hitpoint <= 0) // HP가 0이하일 시 사망
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
