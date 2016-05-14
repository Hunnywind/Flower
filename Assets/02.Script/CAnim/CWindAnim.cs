using UnityEngine;
using System.Collections;

public class CWindAnim : MonoBehaviour {

    public CWindMgr _windMgr;
    private Animator _anim;

    void Awake()
    {
        _anim = GetComponent<Animator>();
    }

	// Use this for initialization
	void Start () {
        _windMgr = GameObject.Find("WindMgr").GetComponent<CWindMgr>();

    }
	
	// Update is called once per frame
	void FixedUpdate () {
	    
        if(_windMgr._windSpeed == CWindMgr.WINDSPEED.SLOW)
        {
            _anim.SetBool("Slow", true);
            _anim.SetBool("Mid", false);
            _anim.SetBool("Fast", false);
            
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 45 * (int)_windMgr._windDir, 0), 0.3f * Time.deltaTime);
            
        }
        else if (_windMgr._windSpeed == CWindMgr.WINDSPEED.NORMAL)
        {
            _anim.SetBool("Slow", false);
            _anim.SetBool("Mid", true);
            _anim.SetBool("Fast", false);

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 45 * (int)_windMgr._windDir, 0), 0.3f * Time.deltaTime);
        }
        else if (_windMgr._windSpeed == CWindMgr.WINDSPEED.FAST)
        {
            _anim.SetBool("Slow", false);
            _anim.SetBool("Mid", false);
            _anim.SetBool("Fast", true);

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 45 * (int)_windMgr._windDir, 0), 0.3f * Time.deltaTime);
        }
    }

    public void Hit()
    {
        _anim.SetTrigger("Hit");
    }
}
