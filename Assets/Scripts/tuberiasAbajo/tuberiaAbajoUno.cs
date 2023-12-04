using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tuberiaAbajoUno : MonoBehaviour
{
    public TMP_Text Score;
    public GameObject Bird;
    private void Start()
    {
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, Random.Range(3, 7), gameObject.transform.localScale.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Restart")
        {
            collision.gameObject.SetActive(false);
            gameObject.transform.position = new Vector2(10f, gameObject.transform.position.y);
            collision.gameObject.SetActive(true);
        }

        if(collision.gameObject.tag == "Score")
        {
            int tempScore = int.Parse(Score.text);
            tempScore++;
            Score.text = tempScore.ToString();
        }
    }
}
