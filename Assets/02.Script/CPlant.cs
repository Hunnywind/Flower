using UnityEngine;
using System.Collections;

public class CPlant : MonoBehaviour
{
    public CFlowerPoolManager _cFlowerMgr;

    protected int hp;
    protected int maxHp;
    protected int clickCount;

    protected virtual void Init()
    {
        hp = maxHp;
        clickCount = 0;
    }

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
    protected virtual void Start()
    {
        _cFlowerMgr = GameObject.Find("FlowerPoolManager").GetComponent<CFlowerPoolManager>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {

    }

    protected virtual void OnMouseDown()
    {
        clickCount++;
    }

    protected virtual void DamagedPlant(int dmg)
    {
        
    }
}
