using UnityEngine;
using System.Collections;

public class CGameMgr : MonoBehaviour {

    public GameObject _seed;

    [SerializeField]
    private float timer;


	// Use this for initialization
	void Start () {
        StartCoroutine(TimerCoroutine());
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _seed.SetActive(true);
            _seed.GetComponent<CSpread>().SpreadInit();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            _seed.SetActive(true);
            _seed.GetComponent<CSpread>().Init();
        }
    }

    IEnumerator TimerCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(timer);
            {
                Debug.Log("Timer Active!");
            }
        }
    }
}
