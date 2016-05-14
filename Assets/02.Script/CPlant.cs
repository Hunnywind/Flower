using UnityEngine;
using System.Collections;

public class CPlant : MonoBehaviour {

    protected int hp;
    protected int maxHp;

    public int Hp
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
        }
    }
    public int MaxHp
    {
        get
        {
            return maxHp;
        }
        set
        {
            maxHp = value;
        }
    }
	// Use this for initialization
	protected virtual void Start () {
	
	}

    // Update is called once per frame
    protected virtual void Update () {
	
	}
}
