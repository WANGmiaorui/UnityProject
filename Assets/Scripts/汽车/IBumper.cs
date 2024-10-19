using System.Collections.Generic;
using UnityEngine;

public interface IBumper
{
    GameObject GetBumperPrefab();
}
public interface IBody
{
    GameObject GetBodyPrefab();
}
public interface ILights
{
    GameObject GetLightsPrefab();
}
public interface ITire
{
    GameObject GetTireLPrefab(List<GameObject> leftTires);
    GameObject GetTireRPrefab(List<GameObject> rightTires);
}