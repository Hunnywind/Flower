using UnityEngine;
using System.Collections;

public class CFlowerPoolManager : MonoBehaviour {

    private GameObject level1Pool;
    private CSprout[] level1Flower;

    private GameObject level2Pool;
    private CFlower[] level2Flower;

	// Use this for initialization
	void Start () {
        level1Pool = GameObject.Find("FlowerLevel1Pool");
        // level2Pool = GameObject.Find("FlowerLevel2Pool");

        level1Flower = level1Pool.GetComponentsInChildren<CSprout>();
        // level2Flower = level2Pool.GetComponentsInChildren<CFlower>();

        foreach (CSprout csprout in level1Flower)
        {
            csprout.gameObject.SetActive(false);
        }
	}

    public void SproutEnabled(Vector3 pos)
    {    
        foreach (CSprout csprout in level1Flower)
        {
            Debug.Log("바닥충돌");
            if (!csprout.gameObject.activeSelf)
            {
                csprout.transform.position = pos;
                csprout.gameObject.SetActive(true);
                return;
            }
        }
    }
}
