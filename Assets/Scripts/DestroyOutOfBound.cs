using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    //A variable for the game objects getting destroyed for going out of bounds
    public float topBound = 6.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Bullets getting destroyed if leaves top bound limit
        if (transform.position.y > topBound)
        {
            Destroy(gameObject);
        }
    }
}