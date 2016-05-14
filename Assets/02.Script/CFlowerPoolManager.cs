using UnityEngine;
using System.Collections;

public class CFlowerPoolManager : MonoBehaviour {

    private GameObject level1Pool;
    private CFlowerLevel1[] level1Flower;
    private GameObject level2Pool;
    private CFlowerLevel2[] level2Flower;
    private GameObject level3Pool;
    private CFlowerLevel3_1[] level3_1Flower;
    private CFlowerLevel3_2[] level3_2Flower;
    private CFlowerLevel3_3[] level3_3Flower;
    private GameObject level4Pool;
    private CFlowerLevel4[] level4Flower;

   void Start () {
        level1Pool = GameObject.Find("FlowerLevel1Pool");
        level2Pool = GameObject.Find("FlowerLevel2Pool");
        level3Pool = GameObject.Find("FlowerLevel3Pool");
        level4Pool = GameObject.Find("FlowerLevel4Pool");

        level1Flower = level1Pool.GetComponentsInChildren<CFlowerLevel1>();
        level2Flower = level2Pool.GetComponentsInChildren<CFlowerLevel2>();
        level3_1Flower = level3Pool.GetComponentsInChildren<CFlowerLevel3_1>();
        level3_2Flower = level3Pool.GetComponentsInChildren<CFlowerLevel3_2>();
        level3_3Flower = level3Pool.GetComponentsInChildren<CFlowerLevel3_3>();
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
        foreach (CFlowerLevel3_1 _level3_1Flower in level3_1Flower)
        {
            _level3_1Flower.gameObject.SetActive(false);
        }
        foreach (CFlowerLevel3_2 _level3_2Flower in level3_2Flower)
        {
            _level3_2Flower.gameObject.SetActive(false);
        }
        foreach (CFlowerLevel3_3 _level3_3Flower in level3_3Flower)
        {
            _level3_3Flower.gameObject.SetActive(false);
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

        // 레벨2 클릭시 레벨 3_1 생성
        if (flowerLevel == 2)
        {
            foreach (CFlowerLevel3_1 createLevel3_1 in level3_1Flower)
            {
                if (!createLevel3_1.gameObject.activeSelf)
                {
                    createLevel3_1.transform.position = pos;
                    createLevel3_1.gameObject.SetActive(true);
                    createLevel3_1.BeeSpwanStart();
                    return;
                }
            }
        }

        // 레벨2 클릭시 레벨 3_2 생성
        if (flowerLevel == 3)
        {
            foreach (CFlowerLevel3_2 createLevel3_2 in level3_2Flower)
            {
                if (!createLevel3_2.gameObject.activeSelf)
                {
                    createLevel3_2.transform.position = pos;
                    createLevel3_2.gameObject.SetActive(true);
                    return;
                }
            }
        }

        // 레벨2 클릭시 레벨 3_3 생성
        if (flowerLevel == 4)
        {
            foreach (CFlowerLevel3_3 createLevel3_3 in level3_3Flower)
            {
                if (!createLevel3_3.gameObject.activeSelf)
                {
                    createLevel3_3.transform.position = pos;
                    createLevel3_3.gameObject.SetActive(true);
                    return;
                }
            }
        }

        // 레벨3 클릭시 레벨 4 생성
        if (flowerLevel == 5)
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
        if (flowerLevel == 6)
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
        foreach (CFlowerLevel1 _level1Flower in level1Flower)
        {
            //_level1Flower.gameObject.SendMessage("DamagedPlant", 1);
        }
    }
}
