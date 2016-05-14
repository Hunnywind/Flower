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
        level2Flower = level2Pool.GetComponentsInChildren<CFlowerLevel2>();
        level3Flower = level3Pool.GetComponentsInChildren<CFlowerLevel3>();
        level4Flower = level4Pool.GetComponentsInChildren<CFlowerLevel4>();

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

    public void FlowerLevel_Click(int flowerLevel, Vector3 pos)
    {

        if (flowerLevel == 1)
        {
            // 레벨1 클릭시 레벨 2 생성
            foreach (CFlowerLevel2 createLevel2 in level2Flower)
            {
                if (!createLevel2.gameObject.activeSelf)
                {
                    createLevel2.transform.position = pos;
                    createLevel2.gameObject.SetActive(true);
                    return;
                }
            }
        }

        // 레벨2 클릭시 레벨 3 생성
        if (flowerLevel == 2)
        {
            foreach (CFlowerLevel3 createLevel3 in level3Flower)
            {
                if (!createLevel3.gameObject.activeSelf)
                {
                    createLevel3.transform.position = pos;
                    createLevel3.gameObject.SetActive(true);
                    return;
                }
            }
        }

        // 레벨3 클릭시 레벨 4 생성
        if (flowerLevel == 3)
        {
            foreach (CFlowerLevel4 createLevel4 in level4Flower)
            {
                if (!createLevel4.gameObject.activeSelf)
                {
                    createLevel4.transform.position = pos;
                    createLevel4.gameObject.SetActive(true);
                    return;
                }
            }
        }

        // 레벨4 클릭시 레벨 1 생성
        if (flowerLevel == 4)
        {
            foreach (CFlowerLevel1 createLevel1 in level1Flower)
            {
                if (!createLevel1.gameObject.activeSelf)
                {
                    createLevel1.transform.position = pos;
                    createLevel1.gameObject.SetActive(true);
                    return;
                }
            }
        }
    }

    public void Damaged()
    {
        Debug.Log("으앙아픔");
        foreach (CFlowerLevel1 _level1Flower in level1Flower)
        {
            //_level1Flower.gameObject.SendMessage("DamagedPlant", 1);
        }
    }
}
