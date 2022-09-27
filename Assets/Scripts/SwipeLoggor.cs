using UnityEngine;

public class SwipeLoggor : MonoBehaviour
{
    private void Awake()
    {
        SwipeDetection.OnSwipe += SwipeDetector_OnSwipe;
    }
    private void SwipeDetector_OnSwipe(SwipeData data)
    {
        Debug.Log(string.Format("Swipe Position: {0}", data.Direction));
    }
}