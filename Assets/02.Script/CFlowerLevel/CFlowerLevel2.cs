using UnityEngine;
using System.Collections;

public class CFlowerLevel2 : CPlant
{
    public void InitS()
    {
        Init();
    }

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

    public void Damage(int dmg)
    {
        DamagedPlant(dmg);
    }

    protected override void DamagedPlant(int dmg)
    {
        hp -= dmg;
        if (hp <= 0)
        {
            if (clickCount < 5)
            {
                _cFlowerMgr.FlowerLevel_Click(2, transform.position);
                
                gameObject.SetActive(false);
            }
            else if (clickCount < 10)
            {
                _cFlowerMgr.FlowerLevel_Click(3, transform.position);

                gameObject.SetActive(false);
            }
            else
            {
                _cFlowerMgr.FlowerLevel_Click(4, transform.position);

                gameObject.SetActive(false);
            }

        }
    }
}
