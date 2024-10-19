
using UnityEngine;

public class Lights : ILights
{
    public GameObject LightsPrefab { get; private set; }
    public Lights(GameObject light)
    {
        LightsPrefab = light;
        LightsPrefab.transform.localPosition = new Vector3(0, 0, 3.2f);
    }
    public GameObject GetLightsPrefab()
    {
        return LightsPrefab;
    }
}
