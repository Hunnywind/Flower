using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CGameMgr : MonoBehaviour {

    public GameObject _seed;

    public static int flowerCounting = 1;
    public static bool _gameStart = false;

    [SerializeField]
    private float timer;

    public delegate void MgrEvent();
    public MgrEvent mgrEvent;

	// Use this for initialization
	void Start () {
        mgrEvent += GameObject.Find("WindMgr").GetComponent<CWindMgr>().ChangeWind;
        mgrEvent += GameObject.Find("FlowerPoolManager").GetComponent<CFlowerPoolManager>().Damaged;
        mgrEvent += CGoatPool.instance.AddTimer;

        //_seed = GameObject.Find("FlowerLevel4Start");

        StartCoroutine(TimerCoroutine());
        _seed.SetActive(true);
        
        _seed.GetComponent<CFlowerLevel4>().InitS();
        StartCoroutine("IfGameOver");
    }
	
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

    IEnumerator IfGameOver()
    {
        while (flowerCounting > 0)
        {
            yield return new WaitForSeconds(0.5f);
            if (!_gameStart) _gameStart = true;
        }
        if (flowerCounting <= 0)
        {
            SceneManager.LoadScene("End");
        }
    }
}
