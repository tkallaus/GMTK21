using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorchanger : MonoBehaviour
{
    public static SpriteRenderer sprite;
    public static Color colorToChangeTo;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if(colorToChangeTo == null)
        {
            colorToChangeTo = Random.ColorHSV(0, 1, 0.5f, 1, 0.7f, 1, 1, 1);
        }
        sprite.color = Color.Lerp(sprite.color, colorToChangeTo, Time.fixedDeltaTime);
        if (!gameoverscript.gameover)
        {
            if (sprite.color == colorToChangeTo)
            {
                colorToChangeTo = Random.ColorHSV(0, 1, 0.5f, 1, 0.5f, 0.7f, 1, 1);
            }
        }
    }
}
