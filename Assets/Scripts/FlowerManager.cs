﻿using UnityEngine;
using System.Collections;

public class FlowerManager : MonoBehaviour {
    public static FlowerManager instance = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
