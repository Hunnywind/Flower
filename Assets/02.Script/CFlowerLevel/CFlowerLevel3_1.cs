using UnityEngine;
using System.Collections;

public class CFlowerLevel3_1 : CPlant {

    private int _beeCount = 0;
    private CBee[] cBee;

    

    protected override void Init()
    {
        maxHp = 20;
        base.Init();
    }

    protected override void Start()
    {
        base.Start();
    }

    public void BeeSpwanStart()
    {
        StartCoroutine("BeeSpwan");
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator BeeSpwan()
    {
        while (_beeCount <= 3)
        {
            int rate = Random.Range(0, 10);
            if (rate < 7)
            {
                Vector3 pos = transform.position;
                pos.x += (Random.Range(10f, 15f));
                pos.y += (Random.Range(1,2));
                pos.z += (Random.Range(10f, 15f));
           
                GameObject bee = CBeePool.instance.AddBee(pos);
                bee.GetComponent<CBee>().SetTarget(transform.position);
                _beeCount = 3;
            }
            yield return new WaitForSeconds(5f);
            ++_beeCount;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Bee")
        {
            _cFlowerMgr.FlowerLevel_Click(5, transform.position);
            collider.transform.position = Vector3.zero;
            collider.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }

}
