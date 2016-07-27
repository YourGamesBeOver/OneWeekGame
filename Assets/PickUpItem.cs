using UnityEngine;

public class PickUpItem : Objective
{

    public bool Held = false;
    public override void ObjectiveBehavior(GameObject collidedWith)
    {
        base.ObjectiveBehavior(collidedWith);

        //so that we don't immediately pick it back up
        if (Input.GetAxis("Let Go") > 0.1f)
        {
            return;
        }

        transform.SetParent(collidedWith.transform, true);
        Held = true;
        Interactable = false;
    }

    public void LetGo()
    {
        transform.SetParent(null);
        Held = false;
        Interactable = true;
    }

    private void Update()
    {
        if (!Held) return;
        if (Input.GetAxis("Let Go") > 0.1f)
        {
            LetGo();
        }
    }
}
