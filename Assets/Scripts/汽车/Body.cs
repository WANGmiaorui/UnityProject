using UnityEngine;
/// <summary>
/// ������ʵ��
/// </summary>
public class Body : IBody
{
    public GameObject BodyPrefab { get; private set; }
    
    public Body(GameObject body)
    {
        BodyPrefab = body;
        BodyPrefab.transform.localPosition = new Vector3(0,0,0);
    }
    public GameObject GetBodyPrefab()
    {
        return BodyPrefab;
    }
}
