﻿using UnityEngine;
using System.Collections;

public class CFlowerLevel1 : CPlant
{
    
    public void InitS()
    {
        
        Init();
    }

    protected override void Init()
    {
        maxHp = 30;
        base.Init();
    }

    protected override void OnMouseDown()
    {
        
        _cFlowerMgr.FlowerLevel_Click(1, transform.position);
        Clean();
        gameObject.SetActive(false);
    }

    protected override void Start () {
        base.Start();
	}

    protected override void Update () {
        base.Update();
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
            Clean();
            gameObject.SetActive(false);
        }
    }


}
