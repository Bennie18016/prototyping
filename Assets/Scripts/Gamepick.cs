using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamepick : MonoBehaviour
{
    public void Scene(int index)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(index);
    }
}
