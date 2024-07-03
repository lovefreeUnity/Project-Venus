
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBtn : MonoBehaviour
{
    public void StartGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
