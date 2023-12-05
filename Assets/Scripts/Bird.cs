using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bird : MonoBehaviour
{
    public GameObject tuberiaArriba;
    public bool started;
    public TMP_Text Restart;
    public TMP_Text Start_txt;
    public TMP_Text Score_txt;
    public float velocity = 5f;
    public bool collided;
    public bool god = false;

    void Start()
    {
        GameObject[] tuberiasArriba = GameObject.FindGameObjectsWithTag("TuberiaArriba");
        GameObject[] tuberiasAbajo = GameObject.FindGameObjectsWithTag("TuberiaAbajo");
        Restart.enabled = false;
        Start_txt.enabled = true;
        foreach (GameObject tuberia in tuberiasArriba)
        {

            Vector3 tempPosicion = tuberia.transform.position;
            tuberia.GetComponent<Rigidbody2D>().velocity = Vector2.left * velocity;
        }

        foreach (GameObject tuberia in tuberiasAbajo)
        {
            Vector3 tempPosicion = tuberia.transform.position;
            tuberia.GetComponent<Rigidbody2D>().velocity = Vector2.left * velocity;
        }
        Score_txt.enabled = false;
        Time.timeScale = 0;
    }

    void Update()
    {
        if (!god)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                god = true;
            }
        }else if (god)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
                god = false;
            }
        }

        if(!started && Input.GetKeyDown(KeyCode.Space))
        {
            initialPush();
        }

        if (!Restart.enabled && Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 1f);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;
            Restart.enabled = false;
            started = true;
        }
    }

    private void initialPush()
    {
        if (!collided)
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.2f;
            started = true;
            Time.timeScale = 1;
            Start_txt.enabled = false;
            Score_txt.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Limite" || collision.gameObject.tag == "TuberiaAbajo" || collision.gameObject.tag == "TuberiaArriba")
        {
            screenBlack();
        }
    }

    private void screenBlack()
    {
        Time.timeScale = 0;
        started = false;
        Restart.enabled = true;
        collided = true;
    }
}
