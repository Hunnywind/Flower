﻿using UnityEngine;
using System.Collections;

public class CFlowerLevel4 : CPlant {


    public CSpread _spread;

    public BoxCollider _boxCollider;

    protected override void OnMouseDown()
    {
        _boxCollider.enabled = false;
        SpreadInit();
        
    }

	// Use this for initialization
	void Awake () {
        _boxCollider = GetComponent<BoxCollider>();
        _spread = GetComponentInChildren<CSpread>();
	}

    public void SpreadInit()
    {
        _spread.SpreadInit();
    }

    public void InitS()
    {
        Init();
    }

    protected override void Init()
    {
        maxHp = 15;
        base.Init();
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
