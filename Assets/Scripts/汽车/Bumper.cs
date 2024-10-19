using UnityEngine;

/// <summary>
/// ±£œ’∏‹
/// </summary>
public class Bumper : IBumper
{
    public GameObject BumperPrefab { get; private set; }
    public Bumper(GameObject bumper)
    {
        BumperPrefab=bumper;
        BumperPrefab.transform.localPosition = new Vector3(0, 0, 3);
    }
    public GameObject GetBumperPrefab()
    {
        return BumperPrefab;
    }
}
