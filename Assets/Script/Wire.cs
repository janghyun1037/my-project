using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    public LineRenderer line;
    public Transform hook;
    Vector2 mousedir;

    public bool isHookActive;
    public bool isLineMax;
    void Start()
    {
        line.positionCount = 2;
        line.endWidth = line.startWidth = 0.05f;
        line.SetPosition(0, transform.position);
        line.SetPosition(1, hook.position);
        line.useWorldSpace = true;
    }

    void Update()
    {
        line.SetPosition(0, transform.position);
        line.SetPosition(1, hook.position);

        if (Input.GetKeyDown(KeyCode.E) && !isHookActive)
        {
            hook.position = transform.position;
            mousedir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            isHookActive = true;
            hook.gameObject.SetActive(true);
        }

        if (isHookActive && !isLineMax)
        {
            hook.Translate(mousedir.normalized * Time.deltaTime * 15);

            if(Vector2.Distance(transform.position, hook.position) > 5)
            {
                isLineMax = true;
            }
        }else if(isHookActive && isLineMax)
        {
            hook.position = Vector2.MoveTowards(hook.position, transform.position, Time.deltaTime * 15);
            if(Vector2.Distance(transform.position, hook.position) < 0.1f)
            {
                isHookActive = false;
                isLineMax = false;
                hook.gameObject.SetActive(false);
            }
        }
    }
}
