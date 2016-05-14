using UnityEngine;
using System.Collections;

public class CFlowerLevel3_1 : CPlant {
    
    protected override void Init()
    {
        maxHp = 20;
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
}
