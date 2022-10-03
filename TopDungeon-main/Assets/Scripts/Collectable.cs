using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Collidable
{
    #region Fields
    //Logic
    protected bool collected;
    #endregion

    #region Methods
    protected override void OnCollide(Collider2D coli)
    {
        if (coli.name == "Player")
            OnCollect();
    }

    protected virtual void OnCollect()
    {
        collected = true;
    }
    #endregion
}
