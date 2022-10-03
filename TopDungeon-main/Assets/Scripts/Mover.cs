using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : Fighter
{
    #region Fields
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;
    public float ySpeed = 0.75f;
    public float xSpeed = 1.0f;
    #endregion

    #region Unity Methods
    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    #endregion

    #region Methods
    protected virtual void UpdateMotor(Vector3 input)
    {
        // moveDelta 리셋
        moveDelta = new Vector3(input.x * xSpeed, input.y * ySpeed, 0);

        // 방향 전환 시 sprite 모습 전환
        if (moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if (moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        // 피격 당했을 때 위치 조정
        moveDelta += pushDirection;

        // pushRecoverySpeed 반영
        pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushRecoverySpeed);

        // 부딪히는 충돌체가 없으면 움직임
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
    }
    #endregion
}
