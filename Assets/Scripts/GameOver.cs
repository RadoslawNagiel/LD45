using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;

    private void OnDestroy()
    {
        gameOverCanvas.gameObject.SetActive(true);
    }
}
