using UnityEngine;
using System.Collections;

public class CPlant : MonoBehaviour
{
    public CFlowerPoolManager _cFlowerMgr;
    public CSound _cSound;

    protected int hp;
    protected int maxHp;
    protected int clickCount;
    protected Health healthbar;

    protected virtual void Init()
    {
        _cFlowerMgr = GameObject.Find("FlowerPoolManager").GetComponent<CFlowerPoolManager>();
        _cSound = GameObject.Find("OneShotSound").GetComponent<CSound>();
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

    
    protected virtual void Start()
    {
        
        
    }

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

    protected virtual void OnEnable()
    {
        if (!CGameMgr._gameStart) return;
        ++CGameMgr.flowerCounting;
        Debug.Log(CGameMgr.flowerCounting);
    }

    protected virtual void OnDisable()
    {
        if (!CGameMgr._gameStart) return;
        --CGameMgr.flowerCounting;
        Debug.Log(CGameMgr.flowerCounting);
    }
}
