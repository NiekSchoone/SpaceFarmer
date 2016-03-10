using UnityEngine;
using System.Collections;

public class Tap : MonoBehaviour
{
    [SerializeField]
    protected Collider2D tapArea;

    protected bool tapping = false;

    protected virtual void Update()
    {
        Vector2 position = TapUtils.GetWorldTapPosition();

        if (TapUtils.OnTapPressed(tapArea.bounds, position))
        {
            tapping = true;
            OnTap();
        }
        if (tapping)
        {
            if (TapUtils.OnTapReleased(tapArea.bounds, position))
            {
                tapping = false;
                OnTapRelease();
            }
        }
    }

    protected void Reset()
    {
        tapArea = GetComponent<Collider2D>();
    }

    public virtual void OnTap()
    {

    }

    public virtual void OnTapRelease()
    {

    }
}
