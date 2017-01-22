using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionWall : MonoBehaviour {
    public ParticleSystem PartiSystem1;
    public ParticleSystem PartiSystem2;
    public ParticleSystem PartiSystem3;
    int nextSyst = 0;
    Vector3 emmissionPoint = new Vector3(0, 0, -0.1f);
    void Start () {

    }
    void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        emmissionPoint = contact.point * 0.8f + this.transform.position * 0.2f;
        if (nextSyst == 0)
        {
            PartiSystem1.transform.position = emmissionPoint;
            PartiSystem1.Emit((int)(Vector3.Magnitude(collision.impulse)));
        } else if (nextSyst == 1)
        {
            PartiSystem2.transform.position = emmissionPoint;
            PartiSystem2.Emit((int)Vector3.Magnitude(collision.impulse));
        } else if (nextSyst == 2)
        {
            PartiSystem3.transform.position = emmissionPoint;
            PartiSystem3.Emit((int)Vector3.Magnitude(collision.impulse));
            
        }
        nextSyst = (nextSyst + 1) % 3;
    }
}
