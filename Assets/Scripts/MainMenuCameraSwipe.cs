// Created by: Nick van Dokkum
// Date: 08/02/2016

using UnityEngine;
using System.Collections;

public class MainMenuCameraSwipe : MonoBehaviour {
    
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 swipe;
    [SerializeField] private bool upDown;
    [SerializeField] private float maxDistance;  //maximum height/to the right it is allowed to be
    [SerializeField] private float minDistance;  //minimum height/to the left it is allowed to be
    [SerializeField] private float minMove;

    private bool touching;

    void Update ()
    {
        //DetectSwipe();
        if (Input.GetMouseButtonDown(0))
        {
            OnMouseButtonDown();
        }
        else if(Input.GetMouseButton(0))
        {
            OnMouseButton();
        }
        if (swipe != Vector2.zero)
        {
            Move();
        }
    }
    void OnMouseButtonDown()
    {
        firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    }
    void OnMouseButton()
    {
        secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        swipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

        firstPressPos = secondPressPos;

        if (upDown)
        {
            swipe.x = 0;
        }
        else
        {
            swipe.y = 0;
        }
    }
    public void DetectSwipe ()
    {
        if (Input.touches.Length > 0) {
            Touch t = Input.GetTouch(0);

            if (t.phase == TouchPhase.Began)
            {
                touching = true;
                swipe = Vector2.zero;
                firstPressPos = new Vector2(t.position.x, t.position.y);
            }
            else if (t.phase == TouchPhase.Moved)
            {
                secondPressPos = new Vector2(t.position.x, t.position.y);
                swipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

                firstPressPos = secondPressPos;
                if (upDown)
                {
                    swipe.x = 0;
                }
                else
                {
                    swipe.y = 0;
                }
            }
            else if (t.phase == TouchPhase.Ended)
            {
                touching = false;
            }

        }
    }
    void Move()
    {
        transform.Translate(-swipe / 30);
        if (!touching)
        {
            swipe /= 1.1f;
            if (swipe.magnitude < minMove)
            {
                swipe = Vector2.zero;
            }
        }
        if (upDown)
        {
            if (transform.position.y > maxDistance)
            {
                SetPosition(true);
            }
            else if (transform.position.y < minDistance)
            {
                SetPosition(false);
            }
        }
        else
        {
            if (transform.position.x > maxDistance)
            {
                SetPosition(true);
            }
            else if (transform.position.x < minDistance)
            {
                SetPosition(false);
            }
        }
    }
    void SetPosition(bool max)
    {
        Vector2 tempPos = transform.position;
        if (upDown)
        {
            if (max)
            {
                tempPos.y = maxDistance;
            }
            else
            {
                tempPos.y = minDistance;
            }
        }
        else
        {
            if (max)
            {
                tempPos.x = maxDistance;
            }
            else
            {
                tempPos.x = minDistance;
            }
        }
        transform.position = new Vector3(tempPos.x,tempPos.y, -10);
        swipe = Vector2.zero;
    }
}