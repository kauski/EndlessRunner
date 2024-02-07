using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10.0f;
    public GameObject particle;
    public Score score;
    public int scoreIncrease = 1;
    // Start is called before the first frame update
    private void Start()
    {
        score = GameObject.Find("UIScore").GetComponent<Score>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //move right
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        //transform.Translate(Vector3.right * Time.deltaTime * speed);
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        //destroy after hits certain obstacle, instantiates particle system.
        if (collision.gameObject.CompareTag("ObstacleDestroy"))
        {
            score.UpdateScore(scoreIncrease);

            Instantiate(particle, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
