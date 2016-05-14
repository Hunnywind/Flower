using UnityEngine;
using System.Collections;

public class CFlowerLevel2 : CPlant
{
    public Transform _effectPos;

    public Object _effect;
    public Object _hitEffect;

    public CWindAnim _cAnim;

    private int _clickCount;
    public void InitS()
    {
        _cSound.OneShotSound(CSound.SOUND.SEEDTOUCH, transform.position);
        Instantiate(_effect, _effectPos.position, Quaternion.identity);
        Init();
    }

    protected override void Init()
    {
        maxHp = 5;
        base.Init();
        Clean();
    }

    void OnEnable()
    {
        StartCoroutine("MouseTouch");
    }

    protected override void OnMouseDown()
    {
        base.OnMouseDown();
        _cSound.OneShotSound(CSound.SOUND.GROWTOUCH, transform.position);
        Instantiate(_hitEffect, _effectPos.position, Quaternion.identity);
        ++_clickCount;
        _cAnim.Hit();
    }

    void Awake()
    {
        _cAnim = GetComponentInChildren<CWindAnim>();
    }

    protected override void Start()
    {
        base.Start();

        _cAnim.GetComponentInChildren<CWindAnim>();
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }

    void UpGrade()
    {

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
            if (clickCount < 5)
            {
                _cFlowerMgr.FlowerLevel_Click(2, transform.position);
                Clean();
                gameObject.SetActive(false);
            }
            else if (clickCount < 10)
            {
                _cFlowerMgr.FlowerLevel_Click(3, transform.position);
                Clean();
                gameObject.SetActive(false);
            }
            else
            {
                _cFlowerMgr.FlowerLevel_Click(4, transform.position);
                Clean();
                gameObject.SetActive(false);
            }

        }
    }

    IEnumerator MouseTouch()
    {
        yield return new WaitForSeconds(3f);
        switch (_clickCount)
        {
            case 0:
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
                _cFlowerMgr.FlowerLevel_Click(2, transform.position);
                Clean();
                break;
            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
                _cFlowerMgr.FlowerLevel_Click(3, transform.position);
                Clean();
                break;
            default:
                _cFlowerMgr.FlowerLevel_Click(4, transform.position);
                Clean();
                break;
        }
        gameObject.SetActive(false);

    }
}
