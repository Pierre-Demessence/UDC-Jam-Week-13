using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Team : MonoBehaviour
{
    [FormerlySerializedAs("color")] [SerializeField]
    private Colors _color;
    
    [FormerlySerializedAs("sprite")] [SerializeField]
    public SpriteRenderer Sprite;

    public Colors Color
    {
        get => _color;
        set
        {
            _color = value;
            SetComponentColor();
        }
    }

    readonly Dictionary<Colors, UnityEngine.Color> _colorToColor = new Dictionary<Colors, UnityEngine.Color>()
        {
            { Colors.RED, UnityEngine.Color.red},
            { Colors.BLUE, UnityEngine.Color.blue},
            { Colors.GREEN, UnityEngine.Color.green},
        };

    private void SetComponentColor()
    {
        Sprite.color = _colorToColor[Color];
    }

    private void Start()
    {
        SetComponentColor();
    }
}
