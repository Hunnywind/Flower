using UnityEngine;
using System.Collections;

public class CFlowerLevel2 : CPlant
{

    private CFlowerPoolManager cfPoolManager;
    protected override void Init()
    {
        maxHp = 5;
        base.Init();
    }
    protected override void OnMouseDown()
    {
        
    }

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {

    }

    void OnDisable()
    {
        StopAllCoroutines();
    }

    void UpGrade()
    {

    }

    protected override void DamagedPlant(int dmg)
    {
        hp -= dmg;
        if (hp <= 0)
        {
            // _cFlowerMgr.FlowerLevel_Click(2, transform.position);
            //gameObject.SetActive(false);
        }
    }
}
