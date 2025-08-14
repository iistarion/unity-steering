using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    private Vector3 _screenPoint;
    private Vector3 _offset;
    private Renderer _renderer;

    [SerializeField]
    private Material _default;
    [SerializeField]
    private Material _highlight;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnMouseDown()
    {
        _renderer.material = _highlight;
        _screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        _offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z));
    }

    private void OnMouseDrag()
    {
        var screenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z);
        var position = Camera.main.ScreenToWorldPoint(screenPoint) + _offset;
        transform.position = position;
    }

    private void OnMouseUp()
    {
        _renderer.material = _default;
    }
}
