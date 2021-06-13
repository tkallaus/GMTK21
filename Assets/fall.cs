using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fall : MonoBehaviour
{
    public float fallSpeed = -1;
    private Rigidbody2D rig;
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        rig.MovePosition(rig.position+new Vector2(0, fallSpeed * Time.fixedDeltaTime));
    }
}
