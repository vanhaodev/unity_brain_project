using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public static BallMovement Instance;
    public Rigidbody2D ballRb;

    [SerializeField] GameObject ballSprite;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
