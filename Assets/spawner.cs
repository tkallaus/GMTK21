using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public fall obstacle;
    private int spawnTimer = 0;
    private int spawnCount = 0;
    public static int spawnSpeed = 50;
    private int fallspd = -20;
    public Transform[] spawnpoints;
    private int waitTimer = 0;
    private bool wait = false;
    private void FixedUpdate()
    {
        if (!gameoverscript.gameover)
        {
            if (spawnTimer % spawnSpeed == 0 && !wait)
            {
                fall obj = Instantiate(obstacle, spawnpoints[dodge.pos + 3]);
                obj.fallSpeed = fallspd;
                spawnCount++;
            }
            if (spawnCount >= 10 && spawnSpeed > 15)
            {
                spawnSpeed -= 5;
                fallspd -= 5;
                spawnCount = 0;
                wait = true;
                Camera.main.gameObject.GetComponent<AudioSource>().pitch += 0.1f;
                FindObjectOfType<ParticleSystem>().startSpeed+=5;
                dodgeFollowP.delaydivision += 0.2f;
            }
            if (wait)
            {
                if(waitTimer > 50)
                {
                    wait = false;
                    waitTimer = 0;
                }
                waitTimer++;
            }
            spawnTimer++;
        }
        else
        {
            spawnTimer = 0;
            spawnCount = 0;
            spawnSpeed = 50;
            fallspd = -20;
        }
    }
}
