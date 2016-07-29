using UnityEngine;

public class Fire : MonoBehaviour
{
    private float Strength;
    private Vector3 startingScale;

    [SerializeField]
    private float MaxStrength = 100f;

    [SerializeField]
    private AnimationCurve SizeCurve;

    [SerializeField]
    private ParticleSystem[] particles;

    // Use this for initialization
    private void Start ()
    {
        Strength = MaxStrength;
        startingScale = transform.localScale;
    }
	
	// Update is called once per frame
	private void Update () {
	    DebugHUD.setValue("Strength", string.Format("{0}/{1} ({2}%)", Strength, MaxStrength, Strength/MaxStrength));
	}

    public void Extinguish(float amount)
    {
        Debug.Log(string.Format("Extinguished {0}", amount));
        Strength -= amount;
        if (Strength <= 0)
        {
            Destroy(gameObject, 10);
            foreach (var p in particles)
            {
                p.Stop();
            }
        }
        else
        {
            transform.localScale = startingScale*SizeCurve.Evaluate(Strength/MaxStrength);
        }
    }
}
