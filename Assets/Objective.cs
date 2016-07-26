using UnityEngine;

public class Objective : MonoBehaviour
{

	void OnTriggerEnter (Collider c)
    {
	    if(c.gameObject.CompareTag("Player"))
        {
            ObjectiveBehavior(c.gameObject);
        }
	}
	
	public virtual void ObjectiveBehavior (GameObject collidedWith)
    {
	
	}
}
