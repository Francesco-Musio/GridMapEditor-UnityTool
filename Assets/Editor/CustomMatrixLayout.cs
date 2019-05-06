using UnityEngine;
using UnityEditor;
using Map;

[CustomPropertyDrawer(typeof(MatrixLayout))]
public class CustomMatrixLayout : PropertyDrawer
{
    public static int TileOptionsCount;
    public static SerializedProperty TilesColor;

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

        if (GUI.Button(new Rect(_position.x + _position.width * 0.22f, _position.y + 45f, _position.width * 0.2f, _position.height), new GUIContent("Reset Map")))
        {
            SerializedProperty matrixRows = _property.FindPropertyRelative("rows");
            matrixRows.arraySize = _property.FindPropertyRelative("mapHeight").intValue;
            for (int i = 0; i < matrixRows.arraySize; i++)
            {
                SerializedProperty row = matrixRows.GetArrayElementAtIndex(i).FindPropertyRelative("row");
                row.arraySize = _property.FindPropertyRelative("mapWidth").intValue;

                for (int j = 0; j < row.arraySize; j++)
                {
                    row.GetArrayElementAtIndex(j).FindPropertyRelative("type").intValue = 0;
                }
            }
        }

        EditorGUI.PropertyField(new Rect(_position.x, _position.y + 70f, _position.width, _position.height), _property.FindPropertyRelative("tiles"), true);
        TileOptionsCount = _property.FindPropertyRelative("tiles").arraySize;
        TilesColor = _property.FindPropertyRelative("tilesColor");

    }
    
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return 18f;
    }
}
