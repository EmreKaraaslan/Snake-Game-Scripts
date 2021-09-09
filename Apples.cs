using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apples : MonoBehaviour
{
    public int score = 0;
    
    [SerializeField] TMPro.TextMeshProUGUI scoreText;
    
    SnakeMovement snakeMovement;

    
    void Start()
    {
        snakeMovement = GameObject.Find("HeadofSnake").GetComponent<SnakeMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        SetScore();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "HeadofSnake")
        {
            score += 10;
            snakeMovement.snakeSpeed += 0.5f;
            snakeMovement.StretchTail();
        }

        if (other.gameObject.tag == "Tail")
        {
            SelectRandomCoordinates();
        }
    }

    void SetScore()
    {
        scoreText.text = "Score: " + score;
    }

    void SelectRandomCoordinates()
    {
        float xValue = Random.Range(-11, 11);
        float zValue = Random.Range(-12, 12);
        transform.position = new Vector3(xValue, 0.39f, zValue);

    }
}
