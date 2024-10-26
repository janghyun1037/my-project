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
        //transform.position = new Vector3(target.position.x, target.position.y + 3, -10f);     // 타겟 위치의 x값, 타겟 위치의 y값 이떄 y를 올릴려면 +를 하면됨
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
    }
}
