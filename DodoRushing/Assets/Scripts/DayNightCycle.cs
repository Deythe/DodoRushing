using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] private float cycleLength = 10f;
    [SerializeField] private float lightMinIntensity = 0.3f;
    [SerializeField] private Light2D globalLight;
    [SerializeField] private float timeOfDay;
    private float factor;
    private float factorInverse;
    [SerializeField] private Gradient dayNightColor;
    
    
    private void Update()
    {
        timeOfDay = Mathf.PingPong(Time.time, cycleLength);
        factor = timeOfDay / cycleLength;
        factorInverse = 1 - factor;
        globalLight.color = dayNightColor.Evaluate(factor);
        globalLight.intensity = Mathf.Clamp(factorInverse, lightMinIntensity, 1f);
    }
}
