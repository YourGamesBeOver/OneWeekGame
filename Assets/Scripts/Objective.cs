using System;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public bool Interactable = true;
    public event Action<GameObject> OnObjectiveTrigger; 

	void OnTriggerEnter (Collider c)
	{
	    if (!Interactable) return;
	    if(c.gameObject.CompareTag("Player"))
        {
            ObjectiveBehavior(c.gameObject);
        }
	}
	
	public virtual void ObjectiveBehavior (GameObject collidedWith)
	{
	    if (OnObjectiveTrigger != null) OnObjectiveTrigger(collidedWith);
	}
}
