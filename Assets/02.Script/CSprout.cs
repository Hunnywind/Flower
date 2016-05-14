using UnityEngine;
using System.Collections;

public class CSprout : MonoBehaviour {

    private CFlowerPoolManager cfPoolManager;

    void Start()
    {
        cfPoolManager = GameObject.Find("FlowerPoolManager").GetComponent<CFlowerPoolManager>();
    }

    void OnEnable()
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
