using UnityEngine;
using System.Collections;

public class CWindMgr : MonoBehaviour {

    public enum WINDROT { N, NE, E, SE, S, SW, W, NW };
    public enum WINDSPEED { SLOW, NORMAL, FAST };

    public WINDROT _windDir = WINDROT.N;
    public WINDSPEED _windSpeed = WINDSPEED.NORMAL;

    private int timer = 0;
	// Use this for initialization
	void Start () {
       
	}
	
    public void ChangeWind()
    {
        timer++;
        if (timer > 1)
        {
            timer = 0;
            _windDir = (WINDROT)Random.Range(0, 8);
            _windSpeed = (WINDSPEED)Random.Range(0, 3);
        }
    }
}
