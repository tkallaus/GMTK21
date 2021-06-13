using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public Transform toFollow;

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, toFollow.position, Vector2.Distance(transform.position, toFollow.position) / 3f);
    }
}
