using UnityEngine;
using System.Collections;

public class CFlowerLevel4 : CPlant {
    
    public CSpread _spread;

    public BoxCollider _boxCollider;
    public CWindAnim _cwindAnim;

    protected override void OnMouseDown()
    {
        Clean();
        _boxCollider.enabled = false;
        _cwindAnim.Hit();
        StartCoroutine("HitCoroutine");
    }

	// Use this for initialization
	void Awake () {
        _cwindAnim = GetComponentInChildren<CWindAnim>();
        _boxCollider = GetComponent<BoxCollider>();
        _spread = GetComponentInChildren<CSpread>();
        
    }

    public void SpreadInit()
    {
        _spread.SpreadInit();
    }

    public void InitS()
    {
        Init();
    }

    protected override void Init()
    {
        maxHp = 15;
        base.Init();

        _cwindAnim.gameObject.SetActive(true);
        _boxCollider.enabled = true;
        foreach(CSeed seed in _spread._seeds)
        {
            seed.gameObject.SetActive(false);
        }
    }

    public void Damage(int dmg)
    {
        DamagedPlant(dmg);
    }

    protected override void DamagedPlant(int dmg)
    {
        hp -= dmg;
        if (hp <= 0)
        {
            Clean();
            gameObject.SetActive(false);
        }
    }

    IEnumerator HitCoroutine()
    {
        yield return new WaitForSeconds(0.7f);
        SpreadInit();
        _cwindAnim.gameObject.SetActive(false);
    }

}
