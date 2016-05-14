using UnityEngine;
using System.Collections;

public class CBeePool : MonoBehaviour {

    public static CBeePool instance;

    private CBee[] cBee;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
    void Start()
    {
        cBee = gameObject.GetComponentsInChildren<CBee>();
        SetActiveFalse();
    }

    void SetActiveFalse()
    {
        foreach (CBee bee in cBee)
        {
            bee.gameObject.SetActive(false);
        }
    }

    public GameObject AddBee(Vector3 pos)
    {
        foreach (CBee bee in cBee)
        {
            if (!bee.gameObject.activeSelf)
            {
                bee.transform.position = pos;
                bee.gameObject.SetActive(true);
                return bee.gameObject;
            }
        }
        return null;
    }
}
