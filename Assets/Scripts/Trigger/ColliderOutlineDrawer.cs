using UnityEngine;

public class ColliderOutlineDrawer
{
    private readonly Collider2D _collider;
    
    private LineRenderer _line;

    public ColliderOutlineDrawer(Collider2D collider, Color color, float lineWidth = 0.05f)
    {
        _collider = collider;

       CreateLineObject(collider);
       Initialize(color, lineWidth);
    }
    
    public void Draw()
    {
        if (_collider == null) return;

        Vector2 size = _collider.bounds.size;
        Vector2 offset = _collider.offset;
        Vector3 center = _collider.transform.position + (Vector3)offset;

        Vector3[] points = new Vector3[4]
        {
            center + new Vector3(-size.x/2, -size.y/2, 0),
            center + new Vector3(-size.x/2,  size.y/2, 0),
            center + new Vector3( size.x/2,  size.y/2, 0),
            center + new Vector3( size.x/2, -size.y/2, 0)
        };

        _line.SetPositions(points);
    }

    public void Destroy()
    {
        if (_line != null)
            Object.Destroy(_line.gameObject);
    }
    
    private void CreateLineObject(Collider2D collider)
    {
        GameObject lineObject = new GameObject($"ColliderOutline_{collider.name}");
        lineObject.transform.parent = collider.transform;
        _line = lineObject.AddComponent<LineRenderer>();
    }

    private void Initialize(Color color, float lineWidth)
    {
        // базовая настройка LineRenderer
        _line.loop = true;
        _line.widthMultiplier = lineWidth;
        _line.useWorldSpace = true;
        _line.material = new Material(Shader.Find("Sprites/Default"));
        _line.startColor = _line.endColor = color;
        _line.positionCount = 4;
    }
}