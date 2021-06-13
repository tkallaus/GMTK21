using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dodge : MonoBehaviour
{
    public static int pos = 0;
    public static follow followTrns;
    private void Start()
    {
        followTrns = GetComponent<follow>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "dodge")
        {
            int randomDir = Random.Range(0, 2);
            switch (randomDir)
            {
                case 0:
                    if(pos < 3)
                    {
                        followTrns.toFollow.Translate(4, 0, 0);
                        pos++;
                    }
                    else
                    {
                        followTrns.toFollow.Translate(-4, 0, 0);
                        pos--;
                    }
                    break;
                case 1:
                    if (pos > -3)
                    {
                        followTrns.toFollow.Translate(-4, 0, 0);
                        pos--;
                    }
                    else
                    {
                        followTrns.toFollow.Translate(4, 0, 0);
                        pos++;
                    }
                    break;
            }
        }
    }
}
