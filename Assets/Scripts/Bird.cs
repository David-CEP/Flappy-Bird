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
    public float velocity = 0.100f;

    void Start()
    {
        Restart.enabled = false;
        initialPush();
    }

    void Update()
    {
        GameObject[] tuberiasArriba = GameObject.FindGameObjectsWithTag("TuberiaArriba");
        GameObject[] tuberiasAbajo = GameObject.FindGameObjectsWithTag("TuberiaAbajo");

        if(Time.timeScale == 1)
        {
            foreach (GameObject tuberia in tuberiasArriba)
            {
                Vector3 tempPosicion = tuberia.transform.position;
                tuberia.transform.position = new Vector3(tempPosicion.x - velocity, tempPosicion.y, tempPosicion.z);
            }

            foreach (GameObject tuberia in tuberiasAbajo)
            {
                Vector3 tempPosicion = tuberia.transform.position;
                tuberia.transform.position = new Vector3(tempPosicion.x - velocity, tempPosicion.y, tempPosicion.z);
            }
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
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.2f;
        started = true;
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

    }
}
