using System;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    private Vector2 fingerDownPos, fingerUpPos;
    public bool detectSwipeAfterRelease = false;
    [SerializeField] private float minDistSwipe = 20f;

    public static event Action<SwipeData> OnSwipe;

    private void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerUpPos = touch.position;
                fingerDownPos = touch.position;
            }

            if (!detectSwipeAfterRelease && touch.phase == TouchPhase.Moved)
            {
                fingerDownPos = touch.position;
                DetectSwipe();
            }

            if (touch.phase == TouchPhase.Ended)
            {
                fingerDownPos = touch.position;
                DetectSwipe();
            }
        }
    }

    private void DetectSwipe()
    {
        if (SwipeDistanceCheckMet())
        {
            if (IsVerticalSwipe())
            {
                var Direction = fingerDownPos.y - fingerUpPos.y > 0 ? SwipeDirection.Up : SwipeDirection.Down;
                SendSwipe(Direction);
            }
            else
            {
                var Direction = fingerDownPos.x - fingerUpPos.x > 0 ? SwipeDirection.Right : SwipeDirection.Left;
                SendSwipe(Direction);
            }
        }
    }

    private bool SwipeDistanceCheckMet()
    {
        return VerticalMovementDistance() > minDistSwipe || HorizontalMovementDistance() > minDistSwipe;
    }

    private bool IsVerticalSwipe()
    {
        return VerticalMovementDistance() > HorizontalMovementDistance();
    }
    private float VerticalMovementDistance()
    {
        return Mathf.Abs(fingerDownPos.y - fingerUpPos.y);
    }

    private float HorizontalMovementDistance()
    {
        return Mathf.Abs(fingerDownPos.x - fingerUpPos.x);
    }

    private void SendSwipe(SwipeDirection direction)
    {
        SwipeData swipeData = new SwipeData()
        {
            Direction = direction,
            StartPosition = fingerDownPos,
            EndPosition = fingerUpPos
        };
        OnSwipe(swipeData);
    }
}
public struct SwipeData
{
    public Vector2 StartPosition, EndPosition;
    public SwipeDirection Direction;
}

public enum SwipeDirection
{
    Up,
    Down,
    Left,
    Right
}
