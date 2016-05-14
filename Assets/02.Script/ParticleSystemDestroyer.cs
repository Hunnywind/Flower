using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace UnityStandardAssets.Utility
{
    public class ParticleSystemDestroyer : MonoBehaviour
    {
        public ParticleSystem _particleSystem;
        
        void Awake()
        {
            _particleSystem = GetComponent<ParticleSystem>();
        }

        void Start()
        {

            float destroytime = _particleSystem.duration;
            Destroy(gameObject, destroytime-0.03f);
        }
        
    }
}
