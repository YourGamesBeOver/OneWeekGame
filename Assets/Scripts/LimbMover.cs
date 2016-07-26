using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class LimbMover : MonoBehaviour
{
    public string Axis;
    public float ForceScale = 10f;
    public float MaxForce = 1000f;

    private Rigidbody rgb;
    
	private void Start ()
	{
	    rgb = GetComponent<Rigidbody>();
	}
	
	private void FixedUpdate ()
    {
	    if (Input.GetButton(Axis))
	    {
	        Vector3 mouseDelta = new Vector3 {x = Mathf.Clamp01(Input.GetAxis("Horizontal")), y = Mathf.Clamp01(Input.GetAxis("Vertical")), z = Mathf.Clamp01(Input.mouseScrollDelta.y)};
	        if (Input.GetButton("Alt"))
	        {
	            var t = mouseDelta.y;
	            mouseDelta.y = mouseDelta.z;
	            mouseDelta.z = t;
	        }
	        var worldDelta = Camera.main.transform.TransformDirection(mouseDelta);
	        var force = Vector3.ClampMagnitude(worldDelta*ForceScale, MaxForce);
            rgb.AddForce(force);
	    }
	}
}
