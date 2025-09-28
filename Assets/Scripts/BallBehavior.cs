using TMPro; //required for TextMeshPro
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    //Ball's speed
    public float speed= 2.0f;
    //how much hit before split / destroy
    public int hitCount = 3;

    //Ball's smaller version
    public GameObject smallBallPrefab;
    //number of small balls spawn
    public int splits = 2;
    //split stopper
    public float minSplit = 0.3f;
    //
    private Rigidbody2D rbody;

    //Provide the remaining HP of Ball Health
    public TextMeshPro hP;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //give random horizontal direction
        rbody = GetComponent<Rigidbody2D>();
        float direction = Random.value < 0.5f ? -1f : 1f;

        UpdateHP();
    }

    //
    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Bullet")) {
            //Destroy Bullet
            Destroy(other.gameObject);
            TakeHit();
        }
    }

    //Determine the Hits before Ball's Split
    void TakeHit()
    {
        hitCount -= 1;
        UpdateHP();
        if(hitCount<=0) {
            if(transform.localScale.x > minSplit)   {
                Split();
            }
            Destroy(gameObject);
        }
    }

    //
    void UpdateHP()
    {
        if(hP != null)
            hP.text = hitCount.ToString();
    }
    //Splits the Ball
    void Split()    {
        for (int i = 0; i < splits; i++)    {
            GameObject newBall = Instantiate(smallBallPrefab, transform.position, Quaternion.identity);
            
            //Sets Balls' Scale to Half
            newBall.transform.localScale = transform.localScale * 0.5f;

            //Push Ball Apart Horizontally
            Rigidbody2D newRbody = newBall.GetComponent<Rigidbody2D>();
            float direction = (i == 0) ? -1f : 1f;
            newRbody.linearVelocity = new Vector2(direction * speed, speed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}