using UnityEngine;
using System.Collections;

public class GreaseGun : MonoBehaviour
{
    [SerializeField]
    private PickUpItem pickup;

    private Rigidbody rgb;

    [SerializeField]
    private ParticleSystem particles;

    [SerializeField]
    private float fireForce = 10;

    [System.NonSerialized]
    public int FuelUsed = 0;

	// Use this for initialization
	void Start ()
	{
	    pickup.OnObjectiveTrigger += other => rgb = other.GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
	    if (!pickup.Held) return;
        DebugHUD.setValue("Fuel Used", FuelUsed);
	    if (Input.GetAxis("Fire") > 0.1f)
	    {
	        FuelUsed++;
	        particles.Emit(1);
            rgb.AddForceAtPosition(transform.forward * -1 * fireForce, transform.position);
	    }
	}
}
