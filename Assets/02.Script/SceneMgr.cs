using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneMgr : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void MainSceneButton()
    {
        SceneManager.LoadScene("start");
    }

    public void GameButton()
    {
        SceneManager.LoadScene("Game_Seed");
    }
    public void CreditButton()
    {
        SceneManager.LoadScene("Credit");
    }
}
