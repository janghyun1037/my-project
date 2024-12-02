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
        if (collision.gameObject.tag == "Ground")//Player 스크립트를 포함한 오브젝트가 그라운드라는 오브젝트 태그에 닿았을 때
        {
            if (jumpCount > 2) jumpCount = 2; //만약 jumpCount가 2를 넘으면 jumpCount를 2로 초기화를 한다.(예외처리) 
            jumpCount = 2;
        }
    }
    //-----------------------------------매서드

    //-----------------------------------점프
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount <= 2 && jumpCount > 0) //jumpCount가 2보다 작거나 같고 0보다 클 때  
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse); //ForceMode2D.Impulse란 총알 발사나 폭발같은 순간적으로 힘이 가해질 때 사용된다.
            jumpCount--; //점프(Space)를 누를 때마다 jumpCount가 1씩 감소한다.
        }
    }
    //-----------------------------------움직임
    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        Debug.Log("Horizontal Input: " + h); // 입력 값 확인
        rb.velocity = new Vector2(h * moveSpeed, rb.velocity.y);
    }
    //-----------------------------------대쉬
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
    //-----------------------------------축 고정
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