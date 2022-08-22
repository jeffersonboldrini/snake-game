
using UnityEngine;


public class FoodScript : MonoBehaviour
{
    private float upValueFood = 10f;
    private float downValueFood = -10f;
    private float rightValueFood = 22f;
    private float leftValueFood = -22f;


    private void Start()
    {
        RandomPosition();
    }

    private void RandomPosition()
    {
        this.transform.position = new Vector3(Random.Range(leftValueFood,rightValueFood),
        Random.Range(downValueFood,upValueFood),0.0f);     
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("Player"))
        {
            RandomPosition();
        }
    }
}
