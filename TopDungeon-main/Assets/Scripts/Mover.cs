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
        // moveDelta ����
        moveDelta = new Vector3(input.x * xSpeed, input.y * ySpeed, 0);

        // ���� ��ȯ �� sprite ��� ��ȯ
        if (moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if (moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        // �ǰ� ������ �� ��ġ ����
        moveDelta += pushDirection;

        // pushRecoverySpeed �ݿ�
        pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushRecoverySpeed);

        // �ε����� �浹ü�� ������ ������
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
