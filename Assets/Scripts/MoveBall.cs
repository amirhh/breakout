using System;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    readonly float H_EDGE = 7.75f;
    readonly float V_EDGE = 4.25f;
    public Vector2 speed = new Vector2(4, -4);
    bool ballServed = false;
    public GameObject[] bricks;
    public int score = 0;
    private Text txt;
    private Text msgTxt;
    private Button btn;

    void Start()
    {
        txt = GameObject.Find("Canvas/Score").GetComponent<Text>();
        msgTxt = GameObject.Find("Canvas/Message").GetComponent<Text>();
        btn = GameObject.Find("Canvas/Button").GetComponent<Button>();
        btn.gameObject.SetActive(false);
    }

    void Update()
    {
        bricks = GameObject.FindGameObjectsWithTag("Brick");
        if (Input.GetButton("Fire1") && !ballServed)
        {
            ballServed = true;
            StartCoroutine(Run());
        }
    }

    IEnumerator Run()
    {
        while (ballServed && bricks.Length > 0)
        {
            Vector3 delta = speed * Time.deltaTime;
            Vector3 newPos = transform.position + delta;
            if (newPos.x < -H_EDGE)
            {
                newPos.x = -H_EDGE;
                speed.x *= -1;
            }
            else if (newPos.x > H_EDGE)
            {
                newPos.x = H_EDGE;
                speed.x *= -1;
            }
            else if (newPos.y > V_EDGE)
            {
                newPos.y = V_EDGE;
                speed.y *= -1;
            }
            else if (newPos.y < -V_EDGE)
            {
                newPos.y = -V_EDGE;
                speed.y *= 0;
                speed.x *= 0;
                msgTxt.text = "game over!";
                btn.gameObject.SetActive(true);
            }
            transform.position = newPos;
            yield return new WaitForEndOfFrame();
        }
        if(bricks.Length == 0)
        {
            msgTxt.text = "you won!";
            btn.gameObject.SetActive(true);
        }
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.tag == "Player")
        {
            speed.y *= -1;
        }else if (c.gameObject.tag == "Brick")
        {
            speed.y *= -1;
            score += 100;
            txt.text = "Score : " + score;
            c.gameObject.SetActive(false);
        }
    }
}