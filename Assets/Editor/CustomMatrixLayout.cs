using UnityEngine;
using UnityEditor;
using Map;

[CustomPropertyDrawer(typeof(MatrixLayout))]
public class CustomMatrixLayout : PropertyDrawer
{
    public override void OnGUI(Rect _position, SerializedProperty _property, GUIContent _label)
    {
        // non dovrebbero andare sotto al valore 2
        _property.FindPropertyRelative("mapWidth").intValue = EditorGUI.IntField(_position, "Map Width", _property.FindPropertyRelative("mapWidth").intValue);
        _property.FindPropertyRelative("mapHeight").intValue = EditorGUI.IntField(
            new Rect(_position.x, _position.y + 20f, _position.width, _position.height),
            "Map Height",
            _property.FindPropertyRelative("mapHeight").intValue);


        if (GUI.Button(new Rect(_position.x, _position.y + 45f, _position.width * 0.2f, _position.height), new GUIContent("Edit Map")))
        {
            SerializedProperty rows = _property.FindPropertyRelative("rows");
            rows.arraySize = _property.FindPropertyRelative("mapHeight").intValue;
            for (int i = 0; i < rows.arraySize; i++)
            {
                SerializedProperty row = rows.GetArrayElementAtIndex(i).FindPropertyRelative("row");
                row.arraySize = _property.FindPropertyRelative("mapWidth").intValue;
            }
            
            MapEditorWindow.Show(_property);
        }

    }
    
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return 18f;
    }
}
