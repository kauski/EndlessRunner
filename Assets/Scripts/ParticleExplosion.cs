using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleExplosion : MonoBehaviour
{
    public ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
        //plays particle when projectile.cs has hit specific object.
        particle.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
