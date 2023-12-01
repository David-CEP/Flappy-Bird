using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bird : MonoBehaviour
{
    private Vector2 initialBird = new Vector2(-5f, 0f);
    public GameObject tuberiaArriba;
    public bool started;
    public TMP_Text Restart;
    public GameObject mainTuberia;

    void Start()
    {
        Vector3[] coords = new Vector3[]{ mainTuberia.GetComponentInChildren<tuberiaAbajoUno>().transform.position };
        Restart.enabled = false;
        initialPush();
    }

    void Update()
    {
        GameObject[] tuberias = GameObject.FindGameObjectsWithTag("Tuberia");
        int i = 0;
        foreach (GameObject tuberia in tuberias)
        {
            Vector3 tempPosicion = tuberia.transform.position;
            coords[i] = tempPosicion;
            i++;
            tuberia.transform.position = new Vector3(tempPosicion.x - 0.002f, tempPosicion.y, tempPosicion.z);
        }

        if (!Restart.enabled && Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 1f);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Time.timeScale = 1;
            Restart.enabled = false;
        }
    }

    private void initialPush()
    {
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.2f;
        started = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Limite" || collision.gameObject.tag == "Tuberia")
        {
            screenBlack();
        }
    }

    private void screenBlack()
    {
        GameObject[] tuberias = GameObject.FindGameObjectsWithTag("Tuberia");
        transform.position = initialBird;
        int i = 0;
        foreach (GameObject tuberia in tuberias)
        {
            tuberia.transform.position = coords[i];
            i++;
        }
        Time.timeScale = 0;
        started = false;
        Restart.enabled = true;

    }
}
