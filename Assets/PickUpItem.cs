using UnityEngine;

public class PickUpItem : Objective
{
    public override void ObjectiveBehavior(GameObject collidedWith)
    {
        base.ObjectiveBehavior(collidedWith);

        transform.position = collidedWith.transform.position;
        transform.SetParent(collidedWith.transform);
    }
}
