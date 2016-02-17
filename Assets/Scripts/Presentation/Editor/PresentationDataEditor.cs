using UnityEngine;
using UnityEditor;  
using UnityEditorInternal;

namespace Presentation
{
	[CustomEditor(typeof(PresentationData))]
	public class PresentationDataEditor : Editor
	{
		private ReorderableList list;

		private void OnEnable()
		{
			list = new ReorderableList(serializedObject, serializedObject.FindProperty("Slides"), true, true, true, true);

			list.drawElementCallback =  
			(Rect rect, int index, bool isActive, bool isFocused) => {
				var element = list.serializedProperty.GetArrayElementAtIndex(index);
				rect.y += 2;
				EditorGUI.PropertyField(
					new Rect(rect.x, rect.y, 60, EditorGUIUtility.singleLineHeight),
					element.FindPropertyRelative("TitleText"), GUIContent.none);
				EditorGUI.PropertyField(
					new Rect(rect.x + 60, rect.y, rect.width - 60 - 100, EditorGUIUtility.singleLineHeight),
					element.FindPropertyRelative("DescriptionText"), GUIContent.none);
				EditorGUI.PropertyField(
					new Rect(rect.x + rect.width - 100, rect.y, 100, EditorGUIUtility.singleLineHeight),
					element.FindPropertyRelative("Slide"), GUIContent.none);
			};
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update();
			list.DoLayoutList();
			serializedObject.ApplyModifiedProperties();
		}
	}
}
