using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tuberiaArribaUno : MonoBehaviour
{
    public GameObject tuberiaRespectiva;
    private void Start()
    {
        Vector3 tempScale = new Vector3(gameObject.transform.localScale.x, Random.Range(3, 9), gameObject.transform.localScale.z);
        if(tuberiaRespectiva.transform.localScale.y >= 6 && tempScale.y >= 6)
        {
            tempScale.y -= 4;
        }
        gameObject.transform.localScale = tempScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Restart")
        {
            collision.gameObject.SetActive(false);
            gameObject.transform.position = new Vector2(10f, gameObject.transform.position.y);
            Vector3 tempScale = new Vector3(gameObject.transform.localScale.x, Random.Range(3, 9), gameObject.transform.localScale.z);
            if (tuberiaRespectiva.transform.localScale.y >= 6 && tempScale.y >= 6)
            {
                tempScale.y -= 4;
            }
            gameObject.transform.localScale = tempScale;
            collision.gameObject.SetActive(true);
        }
    }
}
