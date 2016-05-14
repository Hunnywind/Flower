using UnityEngine;
using System.Collections;

public class CFlowerPoolManager : MonoBehaviour {

    private GameObject level1Pool;
    private CFlowerLevel1[] level1Flower;
    private GameObject level2Pool;
    private CFlowerLevel2[] level2Flower;
    private GameObject level3Pool;
    private CFlowerLevel3[] level3Flower;
    private GameObject level4Pool;
    private CFlowerLevel4[] level4Flower;



   // Use this for initialization
   void Start () {
        level1Pool = GameObject.Find("FlowerLevel1Pool");
        level2Pool = GameObject.Find("FlowerLevel2Pool");
        level3Pool = GameObject.Find("FlowerLevel3Pool");
        level4Pool = GameObject.Find("FlowerLevel4Pool");

        level1Flower = level1Pool.GetComponentsInChildren<CFlowerLevel1>();
        level2Flower = level1Pool.GetComponentsInChildren<CFlowerLevel2>();
        level3Flower = level1Pool.GetComponentsInChildren<CFlowerLevel3>();
        level4Flower = level1Pool.GetComponentsInChildren<CFlowerLevel4>();

        SetActiveFalse();
   }

   void SetActiveFalse()
   {
       foreach (CFlowerLevel1 _level1Flower in level1Flower)
       {
           _level1Flower.gameObject.SetActive(false);
       }

       foreach (CFlowerLevel2 _level2Flower in level2Flower)
       {
           _level2Flower.gameObject.SetActive(false);
       }
       foreach (CFlowerLevel3 _level3Flower in level3Flower)
       {
           _level3Flower.gameObject.SetActive(false);
       }
       foreach (CFlowerLevel4 _level4Flower in level4Flower)
       {
           _level4Flower.gameObject.SetActive(false);
       }
   }

    public void SproutEnabled(Vector3 pos)
    {
        foreach (CFlowerLevel1 csprout in level1Flower)
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
