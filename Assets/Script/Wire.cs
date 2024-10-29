using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    public LineRenderer Line;
    public Transform Hook;
    Vector2 mousedir;

    public bool isHookActive;
    public bool isLineMax;
    void Start()
    {
        Line.positionCount = 2;
        Line.endWidth = Line.startWidth = 0.05f;
        Line.SetPosition(0, transform.position);
        Line.SetPosition(1, Hook.position);
        Line.useWorldSpace = true;
    }

    void Update()
    {
        Line.SetPosition(0, transform.position);
        Line.SetPosition(1, Hook.position);

        if (Input.GetKeyDown(KeyCode.E) && !isHookActive)
        {
            Hook.position = transform.position;
            mousedir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            isHookActive = true;
            Hook.gameObject.SetActive(true);
        }

        if (isHookActive && !isLineMax)
        {
            Hook.Translate(mousedir.normalized * Time.deltaTime * 15);
            if (Vector2.Distance(transform.position, Hook.position) > 5)
            {
                isLineMax = true;
            }
        }
        else if(isHookActive && !isLineMax)
        {
            Hook.position = Vector2.MoveTowards(Hook.position, transform.position, Time.deltaTime * 15);
            if(Vector2.Distance(transform.position, Hook.position) < 0.1f)
            {
                isHookActive = false;
                isLineMax = false;
                Hook.gameObject.SetActive(false);
            }
        }
    }
}
