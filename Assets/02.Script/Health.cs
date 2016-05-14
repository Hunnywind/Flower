using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour {

    private int maxhealth = 1;
    private int prehealth = 0;
    private Scrollbar HealthBar;

    private GameObject target;
    private Vector3 offset;

    public int MaxHealth
    {
        get { return maxhealth; }
        set { maxhealth = value; }
    }
    public int PreHealth
    {
        get { return prehealth; }
        set { prehealth = value; }
    }
    void Awake()
    {
        HealthBar = (Scrollbar)GetComponent("Scrollbar");
    }
    // Use this for initialization
    void Start () {
	
	}
	// Update is called once per frame
	void Update () {
        HealthBar.size = (float)prehealth / (float)maxhealth;
        Update_position();
    }

    private void Update_position()
    {
        Vector3 updateVector = new Vector3();
        updateVector.x = target.transform.position.x + offset.x;
        updateVector.y = target.transform.position.y + offset.y;
        updateVector.z = target.transform.position.z + offset.z;
        transform.position = updateVector;
    }
    public void SetTarget(GameObject obj)
    {
        target = obj;
    }
    public void Disable()
    {
        HealthBar.size = 0;
        this.transform.FindChild("Background").GetComponent<Image>().enabled = false;
        this.transform.FindChild("Mask").GetComponent<Image>().enabled = false;
        this.transform.FindChild("Mask").FindChild("Health").GetComponent<Image>().enabled = false;
        this.transform.FindChild("Frame").GetComponent<Image>().enabled = false;
    }
}
