using UnityEngine;
using System.Collections;
using Mono.Cecil;

[RequireComponent(typeof(ParticleSystem))]
public class Extinguisher : MonoBehaviour
{
    private ParticleCollisionEvent[] collisionEvents;
    private ParticleSystem particles;

    [SerializeField]
    private float Strength = 1f;

    // Use this for initialization
    void Start()
    {
        particles = GetComponent<ParticleSystem>();
        collisionEvents = new ParticleCollisionEvent[16];
    }

    public void OnParticleCollision(GameObject other)
    {
        if (!other.CompareTag("Fire")) return;
        int safeLength = particles.GetSafeCollisionEventSize();
        if (collisionEvents.Length < safeLength)
        {
            collisionEvents = new ParticleCollisionEvent[safeLength];
        }
        int numCollisionEvents = particles.GetCollisionEvents(other, collisionEvents);

        other.GetComponent<Fire>().Extinguish(numCollisionEvents * Strength);
    }
}
