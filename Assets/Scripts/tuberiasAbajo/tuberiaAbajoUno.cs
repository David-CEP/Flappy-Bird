using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tuberiaAbajoUno : MonoBehaviour
{
    void Start()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Restart")
        {
            collision.gameObject.SetActive(false);
            float tubPos = Random.Range(-3.09f, -5.9f);
            gameObject.transform.position = new Vector2(10f, tubPos);
            collision.gameObject.SetActive(true);
        }
    }
}
