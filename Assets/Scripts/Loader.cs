using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {

    public GameObject gameManager;
    public GameObject flowerManager;
    public GameObject windManager;

    void Awake()
    {
        if(GameManager.instance == null)
        {
            Instantiate(gameManager);
        }
        if (FlowerManager.instance == null)
        {
            Instantiate(flowerManager);
        }
        if (WindManager.instance == null)
        {
            Instantiate(windManager);
        }
    }
}
