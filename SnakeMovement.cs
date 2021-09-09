using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SnakeMovement : MonoBehaviour
{
    public float snakeSpeed;

    [SerializeField] GameObject tail;
    [SerializeField] Transform tailParent;
    
    List<GameObject> tails;
    GameObject newTail;
    Vector3 oldPosition;

    LevelFinish levelFinish;

    

    void Start()
    {
        levelFinish = GetComponent<LevelFinish>();
        tails = new List<GameObject>();
        InstantiateInitialTails();
    }

    private void InstantiateInitialTails()
    {
        for (int i = 0; i < 2; i++)
        {
            newTail = Instantiate(tail, new Vector3(0, 0.39f, i * 10), Quaternion.identity);
            tails.Add(newTail);
            newTail.transform.parent = tailParent;
        }
    }

    // Update is called once per frame
    void Update()
    {
        TurnofSnake();
        MovetheSnake();
    }

    

    void TurnofSnake()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        { 
            transform.Rotate(0, 90f, 0);

        }


        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -90f, 0);

        }
    }

    private void MovetheSnake()
    {
            oldPosition = transform.position;
            transform.Translate(0, 0, snakeSpeed * Time.deltaTime);

        if (tails.Count >= 1)
        {
            tails.Last().transform.position = oldPosition;
            tails.Insert(0, tails.Last());
            tails.RemoveAt(tails.Count - 1);

        }

    }

    public void StretchTail()
    {
        newTail = Instantiate(tail, new Vector3(0, 0.39f, 1), Quaternion.identity);
        tails.Add(newTail);
        newTail.transform.parent = tailParent;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            snakeSpeed = 0;
            Time.timeScale = 0.0f;
            levelFinish.LevelEndSituation();
        }
    }

    
}
