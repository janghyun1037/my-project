using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform target;
    public float speed;
    void Start()
    {
        
    }

    void LateUpdate()
    {
        //transform.position = new Vector3(target.position.x, target.position.y + 3, -10f);     // Ÿ�� ��ġ�� x��, Ÿ�� ��ġ�� y�� �̋� y�� �ø����� +�� �ϸ��
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
    }
}
