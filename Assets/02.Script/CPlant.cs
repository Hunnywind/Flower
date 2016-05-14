using UnityEngine;
using System.Collections;

public class CPlant : MonoBehaviour
{
    public CFlowerPoolManager _cFlowerMgr;

    protected int hp;
    protected int maxHp;
    protected int clickCount;
    protected Health healthbar;

    protected virtual void Init()
    {
        healthbar = HpPool.instance.AddHpbar(gameObject);
        hp = maxHp;
        clickCount = 0;
        if (healthbar != null)
        {
            
            healthbar.MaxHealth = maxHp;
            healthbar.PreHealth = hp;
        }
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
        if(healthbar != null)
        {
            healthbar.PreHealth = hp;
        }
    }

    protected virtual void OnMouseDown()
    {
        clickCount++;
    }

    protected virtual void DamagedPlant(int dmg)
    {

    }
    public void Clean()
    {
        if (healthbar != null)
        {
            healthbar.Disable();
            healthbar.gameObject.SetActive(false);
            healthbar = null;
        }
    }
    public void OnDisable()
    {
        //if (healthbar != null)
        //{
        //    healthbar.Disable();
        //    healthbar.gameObject.SetActive(false);
        //    healthbar = null;
        //}
    }
}
