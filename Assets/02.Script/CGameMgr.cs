using UnityEngine;
using System.Collections;

public class CGameMgr : MonoBehaviour {

    public GameObject _seed;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _seed.SetActive(true);
            _seed.GetComponent<CFlowerLevel4>().SpreadInit();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            _seed.SetActive(true);
            _seed.GetComponent<CFlowerLevel4>().Init();
        }
    }
}
