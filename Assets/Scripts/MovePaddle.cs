using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePaddle : MonoBehaviour
{
    readonly float THE_EDGE = 6.5f;
    public float speed = 6;

    void Update()
    {
        Vector3 position = transform.position;
        float t = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        position.x += t;

        if(position.x < -THE_EDGE)
        {
            position.x = -THE_EDGE;
        }else if (position.x > THE_EDGE)
        {
            position.x = THE_EDGE;
        }
        transform.position = position;
    }
}
