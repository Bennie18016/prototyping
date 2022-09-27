using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swiping : MonoBehaviour
{
    public GameObject Up, Down, Left, Right;

    private void Awake()
    {
        SwipeDetection.OnSwipe += SwipeDetector_OnSwipe;
    }

    private void SwipeDetector_OnSwipe(SwipeData data)
    {
        switch (data.Direction)
        {
            case SwipeDirection.Up:
                Up.SetActive(false);
                StartCoroutine(Active(Up));
                break;
            case SwipeDirection.Down:
                Down.SetActive(false);
                StartCoroutine(Active(Down));
                break;
            case SwipeDirection.Left:
                Left.SetActive(false);
                StartCoroutine(Active(Left));
                break;
            case SwipeDirection.Right:
                Right.SetActive(false);
                StartCoroutine(Active(Right));
                break;

        }
    }

    private IEnumerator Active(GameObject dir)
    {
        yield return new WaitForSeconds(1);
        dir.SetActive(true);
    }
}
