using LunarPaw.Steering.Runtime.Agents;
using System.Collections.Generic;
using UnityEngine;

public class RadiusRenderer : MonoBehaviour
{
    private LineRenderer _radiusRenderer;
    private FlockingController _flockingController;

    void Start()
    {
        _radiusRenderer = GetComponent<LineRenderer>();
        _radiusRenderer.startWidth = 0.05f;
        _radiusRenderer.endWidth = 0.05f;
        _flockingController = FindAnyObjectByType<FlockingController>();
    }

    // Update is called once per frame
    void Update()
    {
        _radiusRenderer.enabled = _flockingController.ShowRadius;
        if (_flockingController.ShowRadius)
            DrawRadius(transform.position);
    }

    private void DrawRadius(Vector3 position)
    {
        var count = 33;
        var countf = 32f;
        var positions = new List<Vector3>();
        _radiusRenderer.positionCount = count;
        for (int i = 0; i < count; i++)
        {
            var pos = position + new Vector3(
                Mathf.Cos(((float)i / countf) * Mathf.PI * 2f),
                Mathf.Sin(((float)i / countf) * Mathf.PI * 2f)
                ) * _flockingController.NeighborDistance;
            positions.Add(pos);
            //_radiusRenderer.SetPosition(i, pos);
        }
        _radiusRenderer.SetPositions(positions.ToArray());
    }
}
