using UnityEngine;
using System.Collections;

public class CFlowerLevel4 : MonoBehaviour {

    public CSpread _spread;

	// Use this for initialization
	void Start () {
        _spread = GetComponentInChildren<CSpread>();
	}

    public void SpreadInit()
    {
        _spread.SpreadInit();
    }

    public void Init()
    {
        _spread.Init();
    }

}
