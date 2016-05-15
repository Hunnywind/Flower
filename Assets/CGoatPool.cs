using UnityEngine;
using System.Collections;

public class CGoatPool : MonoBehaviour
{

    public static CGoatPool instance;

    private int timer = 0;
    private Goat[] cGoats;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
    void Start()
    {
        cGoats = gameObject.GetComponentsInChildren<Goat>();
        SetActiveFalse();
    }

    void SetActiveFalse()
    {
        foreach (Goat goat in cGoats)
        {
            goat.gameObject.SetActive(false);
        }
    }

    public void AddGoat(Vector3 pos)
    {
        foreach (Goat goat in cGoats)
        {
            if (!goat.gameObject.activeSelf)
            {
                goat.transform.position = pos;
                goat.gameObject.SetActive(true);
                return;
            }
        }
        
    }

    public void AddTimer()
    {
        timer++;
        if(timer > 30)
        {
            timer = 0;
            int x = UnityEngine.Random.Range(-45, 42);
            int z = UnityEngine.Random.Range(-44, 51);
            Vector3 newVector = new Vector3(x, 0, z);
            AddGoat(newVector);
        }
    }
}
