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
        if (collision.gameObject.tag == "Ground")//Player ��ũ��Ʈ�� ������ ������Ʈ�� �׶����� ������Ʈ �±׿� ����� ��
        {
            if (jumpCount > 1) jumpCount = 1; //���� jumpCount�� 2�� ������ jumpCount�� 2�� �ʱ�ȭ�� �Ѵ�.(����ó��) 
            jumpCount = 1;
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2 && jumpCount > 0) //jumpCount�� 2���� �۰ų� 0���� Ŭ ��  
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse); //ForceMode2D.Impulse�� �Ѿ� �߻糪 ���߰��� ���������� ���� ������ �� ���ȴ�.
            jumpCount--; //����(Space)�� ���� ������ jumpCount�� 1�� �����Ѵ�.
        }
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        Vector3 pos = transform.position;
        pos.x += h * moveSpeed * Time.deltaTime; //Time.deltaTime�̶� ��ǻ�� ���ɿ� �����ϰ� ���� ������� ������ FPS���� �������ش�.
        transform.position = pos; //���� ��ġ�� pos������ �ʱ�ȭ �����ش�.
    }
}