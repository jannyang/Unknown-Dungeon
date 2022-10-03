using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
    #region Fields
    //데미지 구조
    public int[] damagePoint = { 1, 2, 3, 4, 5, 6, 7 };
    public float[] pushForce = { 2.0f, 2.2f, 2.5f, 3f, 3.2f, 3.6f, 4f };

    //무기 레벨
    public int weaponLevel = 0;
    private SpriteRenderer spriteRenderer;

    //무기 휘두르기
    private Animator anim;
    private float cooldown = 0.2f;
    private float lastSwing;

    #endregion

    #region Unity Methods
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
   
    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - lastSwing > cooldown)
            {
                lastSwing = Time.time;
                Swing();
            }
        }
    }
    #endregion

    #region Methods

    #region 무기 공격 및 데미지 피해
    protected override void OnCollide(Collider2D coli)
    {
        if (coli.tag == "Fighter")
        {
            if (coli.name == "Player")
                return;

            //Create a new damage object, then we'll send it to the fighter we've hit
            Damage dmg = new Damage()
            {
                damageAmount = damagePoint[weaponLevel],
                origin = transform.position,
                pushForce = pushForce[weaponLevel]
            };

            coli.SendMessage("ReceiveDamage", dmg);

            Debug.Log(coli.name);

        }
    }
    #endregion

    #region 무기 애니메이션
    private void Swing()
    {
        anim.SetTrigger("Swing");

    }
    #endregion

    #region 무기 레벨 시스템
    public void UpgradeWeapon()
    {
        weaponLevel++;
        spriteRenderer.sprite = GameManager.instance.weaponSprites[weaponLevel];

        //Changer Stats
    }

    public void SetWeaponLevel(int level)
    {
        weaponLevel = level;
        spriteRenderer.sprite = GameManager.instance.weaponSprites[weaponLevel];
    }
    #endregion
    #endregion
}
