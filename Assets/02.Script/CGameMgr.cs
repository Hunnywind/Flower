using UnityEngine;
using System.Collections;

public class CGameMgr : MonoBehaviour {

    public GameObject _seed;

    [SerializeField]
    private float timer;


    public delegate void MgrEvent();
    public MgrEvent mgrEvent;

	// Use this for initialization
	void Start () {
        mgrEvent += GameObject.Find("WindMgr").GetComponent<CWindMgr>().ChangeWind;
        mgrEvent += GameObject.Find("FlowerPoolManager").GetComponent<CFlowerPoolManager>().Damaged;
        StartCoroutine(TimerCoroutine());
        _seed.SetActive(true);
        _seed.GetComponent<CFlowerLevel4>().InitS();
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
            _seed.GetComponent<CFlowerLevel4>().InitS();
        }
    }

    IEnumerator TimerCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(timer);
            {
                if (mgrEvent != null)
                    mgrEvent();
            }
        }
    }
}
