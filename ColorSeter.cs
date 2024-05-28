using UnityEngine;
using System.Collections.Generic;

public class ColorSeter : MonoBehaviour
{
    [SerializeField] private List<Material> _colors;

    private void Awake()
    {
        SetColor();
    }

    private void SetColor()
    {
        if (TryGetComponent(out Renderer renderer))
        {
            Material material = _colors[Random.Range(0, _colors.Count)];

            renderer.material = material;
        }
    }
}
