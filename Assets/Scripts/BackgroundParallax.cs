using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    public float speedX;
    public float speedY;
    public bool moveInOppositeDirection;
    public bool moveParallax = true;

    private Transform cameraTransform;
    private Vector3 previousCameraPosition;

    void OnEnable()
    {
        GameObject gameCamera = GameObject.FindGameObjectWithTag("MainCamera");
        cameraTransform = gameCamera.transform;
        previousCameraPosition = cameraTransform.position;
    }

    void LateUpdate()
    {
        if (!moveParallax)
            return;

        Vector3 distance = cameraTransform.position - previousCameraPosition;
        float direction = (moveInOppositeDirection) ? -1f : 1f;
        transform.position += Vector3.Scale(distance, new Vector3(speedX, speedY)) * direction;

        previousCameraPosition = cameraTransform.position;
    }
}
