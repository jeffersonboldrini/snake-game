
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SnakeScript : MonoBehaviour
{
    private Rigidbody2D rigidBodySnake;
    private Vector2 vectorSnake = Vector2.right;

    [SerializeField]
    private GameObject bodyPrefab;

    private List<GameObject> snakeBody = new List<GameObject>();
    


    private void Start ()
    {
        rigidBodySnake = GetComponent<Rigidbody2D>();
        snakeBody.Add(this.gameObject);
    }

    private void Update()
    {
        GetSnakeDirection();
    }

    private void FixedUpdate()
    {
        MovingSnake();
        SnakeBodyPositioning();
    }

    private void GetSnakeDirection()
    {
        if(Input.GetKeyDown(KeyCode.W) && vectorSnake.x !=0)
        {
            vectorSnake = Vector2.up;
        }
        else if(Input.GetKeyDown(KeyCode.S) && vectorSnake.x !=0)
        {
            vectorSnake = Vector2.down;
        }
        else if(Input.GetKeyDown(KeyCode.D) && vectorSnake.y !=0)
        {
            vectorSnake = Vector2.right;
        }
        else if(Input.GetKeyDown(KeyCode.A)&& vectorSnake.y !=0)
        {
            vectorSnake = Vector2.left;
        }

    }

    private void MovingSnake()
    {
        rigidBodySnake.position += vectorSnake;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("Food"))
        {
            GrowBody();
        }
        else if(coll.CompareTag("Obstacle"))
        {
            resetSnakeBody();
        }
    }

    private void GrowBody()
    {
        GameObject bodySnake = Instantiate(bodyPrefab);
        bodySnake.transform.position = snakeBody[snakeBody.Count-1].transform.position;
        snakeBody.Add(bodySnake);
    }

    private void SnakeBodyPositioning()
    {
        for(int i = snakeBody.Count-1 ; i > 0;i--)
        {
            snakeBody[i].transform.position = snakeBody[i-1].transform.position;
        }
    }

    private void resetSnakeBody()
    {
        for(int i = 1;i < snakeBody.Count;i++)
        {
            Destroy(snakeBody[i]);
        }
        snakeBody.Clear();
        snakeBody.Add(this.gameObject);
        this.transform.position = Vector3.zero;
    }
}
