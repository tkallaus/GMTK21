using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameoverscript : MonoBehaviour
{
    public GameObject gameovertext;
    public GameObject start;
    public GameObject logo;
    public GameObject scoreText;
    private bool started = false;
    public static bool gameover = false;
    private float timer = 0f;
    private void Start()
    {
        gameover = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "hit")
        {
            GetComponent<SpriteRenderer>().enabled = false;
            gameover = true;
            Camera.main.gameObject.GetComponent<AudioSource>().pitch = 1;
            Camera.main.gameObject.GetComponent<AudioSource>().Stop();
            FindObjectOfType<ParticleSystem>().startSpeed = 10;
            FindObjectOfType<ParticleSystem>().Stop();
            colorchanger.colorToChangeTo = Color.black;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && gameover && (timer > 3f || !started))
        {
            if (!started)
            {
                logo.SetActive(false);
                start.SetActive(false);
                scoreText.SetActive(true);
                started = true;
            }
            foreach(fall g in FindObjectsOfType<fall>())
            {
                Destroy(g.gameObject);
            }
            dodge.pos = 0;
            dodge.followTrns.toFollow.position = new Vector3(0, dodge.followTrns.toFollow.position.y, 0);
            foreach (dodgeFollow d in FindObjectsOfType<dodgeFollow>())
            {
                d.pos = 0;
                d.followTrns.toFollow.position = new Vector3(0, d.transform.position.y);
            }
            foreach (dodgeFollowP d in FindObjectsOfType<dodgeFollowP>())
            {
                d.pos = 0;
                d.followTrns.toFollow.position = new Vector3(0, d.transform.position.y);
            }
            controls.score = 0;
            GetComponent<SpriteRenderer>().enabled = true;
            gameovertext.SetActive(false);
            gameover = false;
            Camera.main.gameObject.GetComponent<AudioSource>().Play();
            FindObjectOfType<ParticleSystem>().Play();
            colorchanger.sprite.color = Color.black;
            dodgeFollowP.delaydivision = 1;
            timer = 0f;
        }
        if (gameover && started)
        {
            timer += Time.deltaTime;
        }
        if(timer > 3f)
        {
            gameovertext.SetActive(true);
        }
    }
}
