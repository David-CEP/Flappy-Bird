using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private Vector2 initialBird = new Vector2(-5f, 0f);
    public GameObject tuberiaArriba;
    public bool started;

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
    }

    private void initialPush()
    {
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.2f;
        started = true;
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
    }

    private void screenBlack()
    {
        GameObject[] tuberias = GameObject.FindGameObjectsWithTag("Tuberia");
        foreach(GameObject tuberia in tuberias)
        {
            Destroy(tuberia, 0);
        }
    }
}
