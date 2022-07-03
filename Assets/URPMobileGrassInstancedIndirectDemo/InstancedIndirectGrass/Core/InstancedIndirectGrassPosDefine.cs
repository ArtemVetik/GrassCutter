using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class InstancedIndirectGrassPosDefine : MonoBehaviour
{
    public int instanceCount = 1000000;
    public float drawDistance = 125;

    private int cacheCount = -1;

    void Start()
    {
        UpdatePosIfNeeded();
    }

    private void Update()
    {
        UpdatePosIfNeeded();
    }

    private void UpdatePosIfNeeded()
    {
        if (instanceCount == cacheCount)
            return;

        Debug.Log("UpdatePos (Slow)");

        //same seed to keep grass visual the same
        UnityEngine.Random.InitState(123);

        //auto keep density the same
        float scale = Mathf.Sqrt((instanceCount / 4)) / 2f;
        transform.localScale = new Vector3(scale, transform.localScale.y, scale);

        //////////////////////////////////////////////////////////////////////////
        //can define any posWS in this section, random is just an example
        //////////////////////////////////////////////////////////////////////////
        List<Vector3> positions = new List<Vector3>(instanceCount);
        for (int i = 0; i < instanceCount; i++)
        {
            Vector3 pos = Vector3.zero;

            pos.x = UnityEngine.Random.Range(-1f, 1f) * transform.lossyScale.x;
            pos.z = UnityEngine.Random.Range(-1f, 1f) * transform.lossyScale.z;

            //transform to posWS in C#
            pos += transform.position;

            positions.Add(new Vector3(pos.x, pos.y, pos.z));
        }

        //send all posWS to renderer
        InstancedIndirectGrassRenderer.instance.allGrassPos = positions;
        cacheCount = positions.Count;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, transform.lossyScale * 2);
    }
}
