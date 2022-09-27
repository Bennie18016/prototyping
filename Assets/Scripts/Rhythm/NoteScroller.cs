using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScroller : MonoBehaviour
{
    public float beatTempo;
    public bool hasStarted;
    public AudioSource _as;
    public GameObject _start;

    private void Start()
    {
        beatTempo = beatTempo / 60f;
    }

    private void Update()
    {
        _start.SetActive(!hasStarted);
        if (!hasStarted)
        {
            if (Input.touchCount > 0)
            {
                hasStarted = true;
                _as.Play();
            }
        }
        else
        {
            transform.position -= new Vector3(0f, beatTempo * Time.deltaTime, 0f);
        }
    }
}
