using UnityEngine;
using UnityEditor;
using System.Collections;
using System;

namespace GridMapEditor
{
    [CustomPropertyDrawer(typeof(Tile))]
    public class CustomTileDisplay : PropertyDrawer
    {
        #region Delegates
        public static Action OnClick;
        #endregion

        Rect rectPosition;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            rectPosition = position;

            if (Event.current.type == EventType.MouseDown && Event.current.button == 0 && rectPosition.Contains(Event.current.mousePosition))
            {
                property.FindPropertyRelative("type").intValue += 1;
                if (CustomMatrixLayout.TileOptionsCount <= property.FindPropertyRelative("type").intValue)
                    property.FindPropertyRelative("type").intValue = 0;

                property.serializedObject.ApplyModifiedProperties();
                if (OnClick != null)
                    OnClick();
            }


            Rect newPosition = position;
            newPosition.width = 15f;
            newPosition.height = 15f;
            newPosition.x += 1.5f;
            newPosition.y += 1.5f;

            if (property.FindPropertyRelative("type").intValue >= CustomMatrixLayout.TileOptionsCount)
                property.FindPropertyRelative("type").intValue = 0;

            EditorGUI.DrawRect(newPosition, CustomMatrixLayout.TilesColor.GetArrayElementAtIndex(property.FindPropertyRelative("type").intValue).colorValue);
            
        }


    }
}
