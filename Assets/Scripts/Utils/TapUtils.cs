using UnityEngine;
using System.Collections;

public class TapUtils : MonoBehaviour
{
    public static Vector2 GetWorldTapPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public static bool OnTapPressed(Bounds area, Vector2 position)
    {
        #if (UNITY_IOS || UNITY_ANDROID) && !UNITY_EDITOR
			if(Input.touchCount > 0)
			{
				Touch touch = Input.GetTouch(0);

				if(touch.phase == TouchPhase.Began)
				{
					if(area.Contains(position))
					{
						return true;
					}
				}
			}
        #else
        if (Input.GetMouseButtonDown(0))
        {
            if (area.Contains(position))
            {
                return true;
            }
        }
        #endif

        return false;
    }

    public static bool OnTapReleased(Bounds area, Vector2 position)
    {
        #if (UNITY_IOS || UNITY_ANDROID) && !UNITY_EDITOR
			if(Input.touchCount > 0)
			{
				Touch touch = Input.GetTouch(0);

				if(touch.phase == TouchPhase.Ended)
				{
					if(area.Contains(position))
					{
						return true;
					}
				}
			}
        #else
        if (Input.GetMouseButtonUp(0))
        {
            if (area.Contains(position))
            {
                return true;
            }
        }
        #endif

        return false;
    }
}

