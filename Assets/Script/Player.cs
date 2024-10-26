using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 10f;
    Rigidbody2D rb;
    int jumpCount = 0;
    public float jumpPower = 10f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Jump();
        Move();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")//Player 스크립트를 포함한 오브젝트가 그라운드라는 오브젝트 태그에 닿았을 때
        {
            if (jumpCount > 1) jumpCount = 1; //만약 jumpCount가 2를 넘으면 jumpCount를 2로 초기화를 한다.(예외처리) 
            jumpCount = 1;
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2 && jumpCount > 0) //jumpCount가 2보다 작거나 0보다 클 때  
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse); //ForceMode2D.Impulse란 총알 발사나 폭발같은 순간적으로 힘이 가해질 때 사용된다.
            jumpCount--; //점프(Space)를 누를 때마다 jumpCount가 1씩 감소한다.
        }
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        Vector3 pos = transform.position;
        pos.x += h * moveSpeed * Time.deltaTime; //Time.deltaTime이란 컴퓨터 성능에 무관하게 여러 사용자의 동일한 FPS값을 보장해준다.
        transform.position = pos; //나의 위치를 pos값으로 초기화 시켜준다.
    }
}