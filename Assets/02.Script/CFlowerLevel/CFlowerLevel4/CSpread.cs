using UnityEngine;
using System.Collections;

public class CSpread : MonoBehaviour {

    public CSeed[] _seeds;
    public CFlowerLevel4 _flowerLevel4;

    private Transform tr;


    // 씨앗을 초기화 해주는 함수
    public void Init()
    {
        foreach (CSeed seed in _seeds)
        {
            seed.gameObject.SetActive(true);
            seed.Init();
            
        }
        _flowerLevel4.gameObject.SetActive(true);
    }

    // 씨앗을 퍼지게 하는 함수
    public void SpreadInit()
    {
        foreach(CSeed seed in _seeds )
        {
            seed.SetTr();
            seed.Spread();
            Spread();
        }
    }
    
    void Awake()
    {
        tr = GetComponent<Transform>();
        _flowerLevel4 = GetComponentInParent<CFlowerLevel4>();
    }

	void FixedUpdate()
    {
        foreach(CSeed seed in _seeds)
        {
            if (seed.gameObject.activeSelf)
                return;
        }
        StartCoroutine("ReStartCoroutine");
    }
	
    // 폭발 힘(원형으로 터지는 효과)
    void Spread()
    {
        Collider[] colls = Physics.OverlapSphere(tr.position, 1.8f);
        foreach (Collider coll in colls)
        {
            Rigidbody rbody = coll.GetComponent<Rigidbody>();
            if (rbody != null)
            {
                rbody.mass = 1.0f;
                rbody.AddExplosionForce(50.0f, tr.position, 0.0f, 1.0f);
            }
        }
    }

    IEnumerator ReStartCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        foreach (CSeed seed in _seeds)
        {
            seed.gameObject.SetActive(true);
            seed.Init();
            
        }
        _flowerLevel4._boxCollider.enabled = true;
        _flowerLevel4.gameObject.SetActive(false);
    }
}
