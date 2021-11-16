using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleHandler : MonoBehaviour
{
    public GameObject particle;
    // Start is called before the first frame update
  public void createParticle(Vector3 v)
    {
        Instantiate(particle, v, particle.transform.rotation);
        Debug.Log($"Particle created at{v.x},{v.y},{v.z}");
    }
}
