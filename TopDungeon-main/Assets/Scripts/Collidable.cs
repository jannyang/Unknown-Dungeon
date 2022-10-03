using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{
    #region Fields
    public ContactFilter2D filter;
    private BoxCollider2D boxCollider;
    private Collider2D[] hits = new Collider2D[10];
    #endregion

    #region Unity Methods
    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void Update()
    {
        //Collision work
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
                continue;

            OnCollide(hits[i]);

            //The array is not cleaned up, so we do it ourself
            hits[i] = null;
        }
    }
    #endregion

    #region Methods
    protected virtual void OnCollide(Collider2D coli)
    {
        Debug.Log(coli.name);
    }
    #endregion
}
