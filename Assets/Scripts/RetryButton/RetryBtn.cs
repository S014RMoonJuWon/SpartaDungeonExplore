using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryBtn : MonoBehaviour
{
    public void OnRetry()
    {
        SceneManager.LoadScene("MainScene");
    }
}
