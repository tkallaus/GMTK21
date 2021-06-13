using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controls : MonoBehaviour
{
    public static Transform pTransform;
    public static int pos = 0;
    public static int score = 0;
    public Text scoreUI;
    public dodgeFollow following;

    private int pMoveTimer = 0;
    private void Start()
    {
        pTransform = transform;
    }
    void Update()
    {
        if (!gameoverscript.gameover)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) && pos < 3 && pMoveTimer>spawner.spawnSpeed)
            {
                transform.Translate(4, 0, 0);
                pos++;
                pMoveTimer = 0;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) && pos > -3 && pMoveTimer > spawner.spawnSpeed)
            {
                transform.Translate(-4, 0, 0);
                pos--;
                pMoveTimer = 0;
            }
        }
        else
        {
            transform.position = Vector3.zero;
            pos = 0;
            pMoveTimer = 0;
        }
    }
    private void FixedUpdate()
    {
        if (!gameoverscript.gameover)
        {
            if (pos == following.pos)
            {
                score++;
            }
            else
            {
                score--;
            }
            scoreUI.text = "Score: " + score;
        }
        pMoveTimer++;
    }
}
