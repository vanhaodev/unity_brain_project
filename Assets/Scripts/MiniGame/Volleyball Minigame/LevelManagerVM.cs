using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerVM : MonoBehaviour
{
    Camera cam;
    public Volleyball[] ball;
    public Trajectory trajectory;
    private Volleyball defaultBall;
    [SerializeField] float PushForce = 4f;

    bool isDragging;

    Vector2 startPoint;
    Vector2 endPoint;
    Vector2 direction;
    Vector2 force;
    float distance;

    private void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 pos = cam.ScreenToWorldPoint(Input.mousePosition);
        if(Input.GetMouseButtonDown(0))
        {
            defaultBall = null;
            for(int i = 0; i < ball.Length; i++)
            {
                if(ball[i].col == Physics2D.OverlapPoint(pos))
                {
                    Time.timeScale = 0;
                    isDragging = true;
                    defaultBall = ball[i];
                    OnDragStart();
                }
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            if (defaultBall != null)
            {
                Time.timeScale = 1f;
                isDragging = false;
                OnDragEnd();
            }
        }
        if(isDragging)
        {
            OnDrag();
        }
    }



    #region Drag

    private void OnDragStart()
    {
        startPoint = cam.ScreenToWorldPoint(Input.mousePosition);

        trajectory.Show();
    }
    private void OnDrag()
    {
        endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        distance = Vector2.Distance(startPoint, endPoint);
        direction = (startPoint - endPoint);
        force = distance * direction * PushForce;

        trajectory.UpdateDots(defaultBall.pos, force);
    }

    private void OnDragEnd()
    {
        defaultBall.Push(force);
        trajectory.Hide();
    }

    #endregion
}
