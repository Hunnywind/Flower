using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {

    public void Push()
    {
        SceneManager.LoadScene("Game_Seed");
    }
    public void Push_Cradit()
    {
        SceneManager.LoadScene("Game_Credit");
    }
}
