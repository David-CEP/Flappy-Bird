using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bird : MonoBehaviour
{
    private Vector2 initialBird = new Vector2(-5f, 0f);
    public GameObject tuberiaArriba;
    public bool started;
    public TMP_Text Press;
    public TMP_Text Title;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 1f);
        }
        GameObject[] tuberias = GameObject.FindGameObjectsWithTag("Tuberia");
        foreach(GameObject tuberia in tuberias)
        {
            Vector3 tempPosicion = tuberia.transform.position;
            tuberia.transform.position = new Vector3(tempPosicion.x - 0.002f, tempPosicion.y, tempPosicion.z);
            
        }

        if (!started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                initialPush();
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Respawn();
        }
    }

    private void initialPush()
    {
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.2f;
        started = true;
        Press.enabled = false;
        Title.enabled = false;
        InvokeRepeating("spawnTuberias", 0, 7);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Limite")
        {
            Die();
        }

        if(collision.gameObject.tag == "Tuberia")
        {
            screenBlack();
        }
    }

    private void spawnTuberias()
    {
        Instantiate(tuberiaArriba, new Vector3(0f, 0f, 0f), Quaternion.identity);
    }
    
    private void Die()
    {
        transform.position = initialBird;
        Time.timeScale = 0;
    }

    private void Respawn()
    {
        Time.timeScale = 1;
    }

    private void screenBlack()
    {
        GameObject[] tuberias = GameObject.FindGameObjectsWithTag("Tuberia");
        foreach(GameObject tuberia in tuberias)
        {
            Destroy(tuberia, 0);
        }
        Die();
    }
}
