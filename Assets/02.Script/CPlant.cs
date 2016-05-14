using UnityEngine;
using System.Collections;

public class CPlant : MonoBehaviour
{
    public CFlowerPoolManager _cFlowerMgr;

    protected int hp;
    protected int maxHp;
    protected int clickCount;

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

    }

    // Update is called once per frame
    protected virtual void Update()
    {

    }

    virtual public void OnEnable()
    {
        hp = MaxHp;
        clickCount = 0;
    }

    protected virtual void OnMouseDown()
    {
        clickCount++;
    }

    public void DamagedPlant(int dmg)
    {
        hp -= dmg;
        if (hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
