using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTextPerson : Collidable
{
    #region Fields
    public string message;

    private float cooldown = 4.0f;
    private float lastShout;
    #endregion

    #region Unity Methods
    protected override void Start()
    {
        base.Start();
        lastShout = -cooldown;
    }
    #endregion

    #region Methods
    protected override void OnCollide(Collider2D coli)
    {
        if (Time.time - lastShout > cooldown)
        {
            lastShout = Time.time;
            GameManager.instance.ShowText(message, 18, Color.white, transform.position + new Vector3(0, 0.16f, 0), Vector3.zero, cooldown);
        }
    }
    #endregion
}
