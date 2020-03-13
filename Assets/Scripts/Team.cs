using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEditor.Experimental.SceneManagement;
using UnityEngine;

public class Team : MonoBehaviour
{
    private readonly Dictionary<Colors, Color> _colorToColor = new Dictionary<Colors, Color>
    {
        {Colors.Red, UnityEngine.Color.red},
        {Colors.Blue, UnityEngine.Color.blue},
        {Colors.Green, UnityEngine.Color.green}
    };
    [SerializeField] [EnumToggleButtons] private Colors _color;

    [SerializeField] private SpriteRenderer _sprite;

    public Colors Color
    {
        get => _color;
        set
        {
            _color = value;
            SetComponentColor();
        }
    }

    private void SetComponentColor()
    {
        _sprite.color = _colorToColor[Color];
    }

    private void Start()
    {
        SetComponentColor();
    }

    private void OnValidate()
    {
        if (PrefabStageUtility.GetCurrentPrefabStage() != null) return;
        SetComponentColor();
    }
}