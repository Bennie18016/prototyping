using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    TMP_Text score;
    public int _score = 0;
    public int _hits = 0;

    private void Awake()
    {
        score = GetComponent<TMP_Text>();
    }
    private void Update()
    {
        score.text = _score.ToString();

        if (_hits == 18)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}
