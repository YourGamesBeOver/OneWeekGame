using UnityEngine;

public class PickUpItem : Objective
{
    public override void ObjectiveBehavior(GameObject collidedWith)
    {
        base.ObjectiveBehavior(collidedWith);

        transform.SetParent(collidedWith.transform, true);
    }
}
