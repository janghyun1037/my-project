using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer playerSpriteRenderer;
    public float moveSpeed;
    Rigidbody2D rb;
    int jumpCount = 0;
    public float jumpPower = 10f;
    private bool isdash;
    public float dashSpeed;
    public float defaultTime;
    public float dashTime = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Jump();
        Move();
        Dash();
        FlipX();
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")//Player ��ũ��Ʈ�� ������ ������Ʈ�� �׶����� ������Ʈ �±׿� ����� ��
        {
            if (jumpCount > 2) jumpCount = 2; //���� jumpCount�� 2�� ������ jumpCount�� 2�� �ʱ�ȭ�� �Ѵ�.(����ó��) 
            jumpCount = 2;
        }
    }
    //-----------------------------------�ż���

    //-----------------------------------����
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount <= 2 && jumpCount > 0) //jumpCount�� 2���� �۰ų� ���� 0���� Ŭ ��  
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse); //ForceMode2D.Impulse�� �Ѿ� �߻糪 ���߰��� ���������� ���� ������ �� ���ȴ�.
            jumpCount--; //����(Space)�� ���� ������ jumpCount�� 1�� �����Ѵ�.
        }
    }
    //-----------------------------------������
    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        Debug.Log("Horizontal Input: " + h); // �Է� �� Ȯ��
        rb.velocity = new Vector2(h * moveSpeed, rb.velocity.y);
    }
    //-----------------------------------�뽬
    void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isdash = true;
        }
        if (dashTime <= 0)
        {
            if (isdash)
            {
                dashTime = defaultTime;
            }
        }
        else
        {
            dashTime -= Time.deltaTime;
            moveSpeed = dashSpeed;
        }
        isdash = false;
    }
    //-----------------------------------�� ����
    void FlipX()
    {
        if (Input.GetKey(KeyCode.D))
        {

            playerSpriteRenderer.flipX = false;

        }
        else if (Input.GetKey(KeyCode.A))
        {

            playerSpriteRenderer.flipX = true;

        }
    }
}