using UnityEngine;
using System.Collections;

public class HpPool : MonoBehaviour {

    public static HpPool instance = null;

    private Health[] hpbars;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
	void Start () {
        hpbars = gameObject.GetComponentsInChildren<Health>();
        SetActiveFalse();
	}
	
    void SetActiveFalse()
    {
        foreach (Health bar in hpbars)
        {
            bar.Disable();
            bar.gameObject.SetActive(false);
        }
    }

    public Health AddHpbar(GameObject obj)
    {
        foreach (Health bar in hpbars)
        {
            if (!bar.gameObject.activeSelf)
            {
                bar.SetTarget(obj);
                bar.gameObject.SetActive(true);
                return bar;
            }
        }
        return null;
    }
    void Update () {
	
	}
}
