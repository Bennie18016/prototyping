using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteHit : MonoBehaviour
{

    public bool canBePressed, pressed;
    public string dir;
    public Score _s;

    private void Awake()
    {
        SwipeDetection.OnSwipe += SwipeDetector_OnSwipe;
    }

    private void SwipeDetector_OnSwipe(SwipeData data)
    {
        if (!canBePressed) return;

        switch (data.Direction)
        {
            case SwipeDirection.Up:
                if (dir.ToLower() == "up") { hit(true); }
                else { hit(false); }
                break;
            case SwipeDirection.Down:
                if (dir.ToLower() == "down") { hit(true); }
                else { hit(false); }
                break;
            case SwipeDirection.Left:
                if (dir.ToLower() == "left") { hit(true); }
                else { hit(false); }
                break;
            case SwipeDirection.Right:
                if (dir.ToLower() == "right") { hit(true); }
                else { hit(false); }
                break;

        }
    }

    private void hit(bool correct)
    {
        Debug.Log(correct);
        if (correct)
        {
            _s._score += 20;
            pressed = true;
            gameObject.SetActive(false);
        }
        else
        {
            _s._score -= 10;
            gameObject.SetActive(false);
            pressed = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Activator"))
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Activator"))
        {
            canBePressed = false;
            if (!pressed) { hit(false); }
            _s._hits++;
        }
    }
}
