using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class PlaneFadeOut : MonoBehaviour
{
    private Renderer ToFade;
    public Transform Target;
    public AnimationCurve FadeCurve;

    void Start()
    {
        ToFade = GetComponent<Renderer>();
    }

	// Update is called once per frame
	void Update ()
	{
	    var color = ToFade.material.color;
	    color.a = FadeCurve.Evaluate(Target.position.y);
        DebugHUD.setValue(string.Format("{0} a", name), color.a);
	    ToFade.material.color = color;
	}
}
