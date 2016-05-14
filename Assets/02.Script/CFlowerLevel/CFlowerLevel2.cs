using UnityEngine;
using System.Collections;

public class CFlowerLevel2 : CPlant
{
    public void InitS()
    {
        Init();
    }

    protected override void Init()
    {
        maxHp = 5;
        base.Init();
    }

    void OnEnable()
    {
        StartCoroutine("MouseTouch");
    }

    void OnMouseDown()
    {
        ++_clickCount;
    }

    protected override void Start()
    {
        base.Start();
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
                
                gameObject.SetActive(false);
            }
            else if (clickCount < 10)
            {
                _cFlowerMgr.FlowerLevel_Click(3, transform.position);

                gameObject.SetActive(false);
            }
            else
            {
                _cFlowerMgr.FlowerLevel_Click(4, transform.position);

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
                break;
            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
                _cFlowerMgr.FlowerLevel_Click(3, transform.position);
                break;
            default:
                _cFlowerMgr.FlowerLevel_Click(4, transform.position);
                break;
        }
        gameObject.SetActive(false);

    }
}
