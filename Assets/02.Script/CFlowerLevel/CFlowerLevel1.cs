﻿using UnityEngine;
using System.Collections;

public class CFlowerLevel1 : CPlant
{
    protected override void OnMouseDown()
    {
        _cFlowerMgr.FlowerLevel_Click(1, transform.position);
        gameObject.SetActive(false);
    }

    // Use this for initialization
    protected override void Start () {
        base.Start();
	}

    // Update is called once per frame
    protected override void Update () {
	
	}
}
