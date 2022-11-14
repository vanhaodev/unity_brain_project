using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public static BallMovement Instance;
    public Rigidbody2D ballRb;
    public ParticleSystem collisionParticle;

    [SerializeField] GameObject ballSprite;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D  (Collision2D collision)
    {
        //cho phép bóng xoay di chuyển
        ballRb.constraints = RigidbodyConstraints2D.None;

        collisionParticle.Play();
        if (collision.gameObject.tag == "Ground")
        {

            Vector2 surfaceNormal = collision.contacts[0].normal;
            ballRb.velocity = Vector2.Reflect(ballRb.velocity, surfaceNormal); 
        }
    }
}
