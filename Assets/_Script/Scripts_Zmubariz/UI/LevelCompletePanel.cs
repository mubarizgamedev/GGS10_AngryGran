using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelCompletePanel : MonoBehaviour
{


    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void NextLevel()
    {
        gameObject.SetActive(false);
    }
}
