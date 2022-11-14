using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public float smoothtimeX, smoothtimeY;
    public Vector2 velocity;

    public GameObject ball;

    public Vector2 minpos, maxpos;
    public bool bound;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
            ball = GameObject.FindGameObjectWithTag("Player");
        else
            ball = GameObject.FindGameObjectWithTag("Basketball");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(this.transform.position.x, ball.transform.position.x, ref velocity.x, smoothtimeX);
        float posY = Mathf.SmoothDamp(this.transform.position.y, ball.transform.position.y, ref velocity.y, smoothtimeY);
        transform.position = new Vector3(posX, posY, transform.position.z);

        if (bound)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minpos.x, maxpos.x),
            Mathf.Clamp(transform.position.y, minpos.y, maxpos.y),
            Mathf.Clamp(transform.position.z, transform.position.z, transform.position.z));
        }
    }
}
