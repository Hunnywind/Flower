using UnityEngine;
using System.Collections;

public class CSpread : MonoBehaviour {

    public CSeed[] _seeds;

    private Transform tr;


    // 씨앗을 초기화 해주는 함수
    public void Init()
    {
        foreach (CSeed seed in _seeds)
        {
            seed.Init();
        }
    }

    // 씨앗을 퍼지게 하는 함수
    public void SpreadInit()
    {
        foreach(CSeed seed in _seeds )
        {
            seed.Spread();
            Spread();
        }
    }
    
    void Awake()
    {
        tr = GetComponent<Transform>();
    }

	// Use this for initialization
	void Start () {
        
    }
	
    // 폭발 힘(원형으로 터지는 효과)
    void Spread()
    {
        Collider[] colls = Physics.OverlapSphere(tr.position, 1.0f);
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
}
