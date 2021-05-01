using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSwipe : MonoBehaviour
{
    private Vector2 startTouchPosition, endTouchPosition;
    public Camera mainCamera;
    public enum SwipeState
    {
        left,
        middle,
        right
    }
    public SwipeState swipeState;

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;

            //if swiped right
            if (endTouchPosition.x < startTouchPosition.x)
            {
                SwipeRight();
            }
            //if swiped left
            if (endTouchPosition.x > startTouchPosition.x)
            {
                SwipeLeft();
            }
        }
    }

    public void SwipeRight()
    {
        if (swipeState == SwipeState.middle)
        {
            LeanTween.moveLocalX(mainCamera.gameObject, 3f, .5f);
            swipeState = SwipeState.right;
        }
        if (swipeState == SwipeState.right)
        {
            return;
        }
        if (swipeState == SwipeState.left)
        {
            LeanTween.moveLocalX(mainCamera.gameObject, 0f, .5f);
            swipeState = SwipeState.middle;
        }
    }

    public void SwipeLeft()
    {
        if (swipeState == SwipeState.middle)
        {
            LeanTween.moveLocalX(mainCamera.gameObject, -3f, .5f);
            swipeState = SwipeState.left;
        }
        if (swipeState == SwipeState.left)
        {
            return;
        }
        if (swipeState == SwipeState.right)
        {
            LeanTween.moveLocalX(mainCamera.gameObject, 0f, .5f);
            swipeState = SwipeState.middle;
        }
    }

}
