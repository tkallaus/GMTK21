using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dodgeFollow : MonoBehaviour
{
    public int pos = 0;
    public follow followTrns;
    private void Start()
    {
        followTrns = GetComponent<follow>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "dodge")
        {
            followTrns.toFollow.Translate((dodge.pos - pos) * 4, 0, 0);
            pos = dodge.pos;
            if (dodge.followTrns.toFollow.position.x != followTrns.toFollow.position.x)
            {
                pos = dodge.pos;
                followTrns.toFollow.position = new Vector3(dodge.followTrns.toFollow.position.x, followTrns.toFollow.position.y, 0);
            }
        }
    }
}
