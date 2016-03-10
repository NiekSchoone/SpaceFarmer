using UnityEngine;
using System.Collections;

public class CameraScroll : MonoBehaviour
{
    private Vector2 firstPressPos;
    private Vector2 secondPressPos;
    private Vector2 currentSwipe;

    // The ID of the touch that began the scroll.
    int ScrollTouchID = -1;
    // The position of that initial touch
    Vector2 ScrollTouchOrigin;

    void Update()
    {
        DetectSwipe();
        DetectEditorSwipe();
    }

    void DetectEditorSwipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //save began touch 2d point
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButtonUp(0))
        {
            //save ended touch 2d point
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            //create vector from the two points
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

            //normalize the 2d vector
            currentSwipe.Normalize();

            Debug.Log(currentSwipe);

            //swipe upwards
            if (currentSwipe.y > 0  /*currentSwipe.x > -0.5f  currentSwipe.x < 0.5f*/)
            {
                Debug.Log("up swipe");
                //Vector3.Lerp(transform.position, currentSwipe, Time.deltaTime * 1);
            }
            //swipe down
            if (currentSwipe.y < 0  /*currentSwipe.x > -0.5f  currentSwipe.x < 0.5f*/)
            {
                Debug.Log("down swipe");
                //Vector3.Lerp(transform.position, currentSwipe, Time.deltaTime * 1);
            }
        }
    }

    void DetectSwipe()
    { 
        foreach (Touch T in Input.touches)
        {
            //Note down the touch ID and position when the touch begins...
            if (T.phase == TouchPhase.Began)
            {
                if (ScrollTouchID == -1)
                {
                    ScrollTouchID = T.fingerId;
                    ScrollTouchOrigin = T.position;
                }
            }
            //Forget it when the touch ends
            if ((T.phase == TouchPhase.Ended) || (T.phase == TouchPhase.Canceled))
            {
                ScrollTouchID = -1;
            }
            if (T.phase == TouchPhase.Moved)
            {
                //If the finger has moved and it's the finger that started the touch, move the camera along the Y axis.
                if (T.fingerId == ScrollTouchID)
                {
                    Vector3 CameraPos = Camera.main.transform.position;
                    Camera.main.transform.position = new Vector3(CameraPos.x, CameraPos.y + T.deltaPosition.y, CameraPos.z);
                }
            }
        }
    }
}
