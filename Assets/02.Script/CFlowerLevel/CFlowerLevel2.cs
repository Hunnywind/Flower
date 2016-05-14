using UnityEngine;
using System.Collections;

public class CFlowerLevel2 : CPlant
{

    private CFlowerPoolManager cfPoolManager;
    protected override void Init()
    {
        maxHp = 20;
        base.Init();
    }
    protected override void OnMouseDown()
    {
        _cFlowerMgr.FlowerLevel_Click(2, transform.position);
        gameObject.SetActive(false);
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
