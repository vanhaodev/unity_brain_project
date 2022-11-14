using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGFollow : MonoBehaviour
{
    Vector2 velocity;

    private Transform cameraTransform;

    void OnEnable()
    {
        cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(Mathf.SmoothDamp(transform.position.x, cameraTransform.position.x, ref velocity.x, 0.5f), Mathf.SmoothDamp(transform.position.y, cameraTransform.position.y, ref velocity.y, 0.5f), 0);
        transform.position = new Vector3(0, Mathf.Clamp(transform.position.y, Vector2.zero.y, Vector2.zero.y), Mathf.Clamp(transform.position.z, transform.position.z, transform.position.z));
    }
}
