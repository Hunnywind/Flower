using UnityEngine;
using System.Collections;

public class CWindMgr : MonoBehaviour {

    public enum WINDROT { N, NE, E, SE, S, SW, W, NW };
    public enum WINDSPEED { SLOW, NORMAL, FAST };

    public WINDROT _windDir = WINDROT.N;
    public WINDSPEED _windSpeed = WINDSPEED.NORMAL;
    

	// Use this for initialization
	void Start () {
        StartCoroutine("ChangeWindCoroutine");
	}
	
    // N초마다 바람의 방향, 세기 체인지
    IEnumerator ChangeWindCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            _windDir = (WINDROT)Random.Range(0, 8);
            _windSpeed = (WINDSPEED)Random.Range(0, 3);
        }
    }
}
