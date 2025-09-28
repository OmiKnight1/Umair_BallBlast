using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //A variable for horizontal Input Speed
    public float hInputSpeed = 10.0f;
    //A variable for horizontal Input
    public float horizontalInput;
    //A variable for horizontal Input Range
    public float hInputRange;

    //A variable for the Bullet from Player game object
    public GameObject bulletPrefab;
    //A variable for the Bullet Upward speed
    public float bulletSpeed = 15.0f;
    //A variable for the bullet's location to be spawned
    public Transform bulletPoint;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Move Player horizontally with A / D or < / >
        float move = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector2.right * move * hInputSpeed * Time.deltaTime);

        //Fire bullets with Left Mouse
        if(Input.GetMouseButton(0)) {
            GameObject bullet = Instantiate(bulletPrefab, bulletPoint.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().linearVelocity = Vector2.up * bulletSpeed;
        }

        //Keep the Player in bounds horizontally
        if (transform.position.x < -hInputRange)
        {
            transform.position = new Vector3(-hInputRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > hInputRange)
        {
            transform.position = new Vector3(hInputRange, transform.position.y, transform.position.z);
        }
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * hInputSpeed);
    }
}