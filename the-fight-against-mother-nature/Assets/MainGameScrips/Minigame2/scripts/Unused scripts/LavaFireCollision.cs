using UnityEngine;

public class LavaFireCollision : MonoBehaviour
{
    ParticleSystem particles;

    void Start()
    {
        particles = GetComponent<ParticleSystem>();
        particles.Stop(); //Stop the particle system at the beginning
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ground"))
        {
            particles.Play();
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Ground"))
        {
            particles.Stop();
        }
    }
}
