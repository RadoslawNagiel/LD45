using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void Restart()
    {
        Debug.Log("działaj");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
