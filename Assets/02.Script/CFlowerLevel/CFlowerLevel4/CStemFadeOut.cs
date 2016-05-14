using UnityEngine;
using System.Collections;

public class CStemFadeOut : MonoBehaviour {
    
    void Awake()
    {
        
    }

	public void StartFadeOut()
    {
        StartCoroutine("FadeOutCoroutine");
    }

    IEnumerator FadeOutCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
       
    } 
}
