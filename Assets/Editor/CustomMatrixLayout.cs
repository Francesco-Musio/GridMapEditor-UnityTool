using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(MatrixLayout))]
public class CustomMatrixLayout : PropertyDrawer
{
    public override void OnGUI(Rect _position, SerializedProperty _property, GUIContent _label)
    {
        // Dedicated space
        EditorGUI.PrefixLabel(_position, _label);
        Rect newPosition = _position;
        newPosition.y += 18f;

        // get map variable from MapData
        SerializedProperty rows = _property.FindPropertyRelative("rows");

        // Get the first row
        for (int j = 0; j < 7; j++)
        {
            SerializedProperty row = rows.GetArrayElementAtIndex(j).FindPropertyRelative("row");
            newPosition.height = 18f;
            newPosition.width = 18f;
            if (row.arraySize != 7)
            {
                row.arraySize = 7;
            }
            for (int i = 0; i < 7; i++)
            {
                EditorGUI.PropertyField(newPosition, row.GetArrayElementAtIndex(i), GUIContent.none);
                newPosition.x += 18f;
            }

            newPosition.x = _position.x;
            newPosition.y += 18f;
        }
        
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return 18f * 8;
    }
}
