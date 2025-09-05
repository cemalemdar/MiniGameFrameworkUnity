#if UNITY_EDITOR
using System.IO;
using Games;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DemoSceneCreator : OdinEditorWindow
{
    [MenuItem("Tools/Demo/Create Demo Scene")]
    private static void OpenWindow()
    {
        GetWindow<DemoSceneCreator>("Demo Scene Creator").Show();
    }

    [Title("Output")]
    [FolderPath(AbsolutePath = false)]
    [Tooltip("Folder to save the .unity scene under (relative to project).")]
    public string SceneFolder = "Assets/Scenes";

    [SuffixLabel(".unity", true)]
    [Tooltip("Scene file name (without extension).")]
    public string SceneName = "DemoScene";

    [Title("Demo Root")]
    [Tooltip("Name of the root GameObject that will hold the DemoGame component.")]
    public string RootObjectName = "Demo Game";

    [Button(ButtonSizes.Large)]
    [GUIColor(0.2f, 0.8f, 0.4f)]
    [PropertySpace(12)]
    public void CreateDemoScene()
    {
        // Validate DemoGame component exists
        var demoGameType = typeof(DemoGameSetup);
        if (demoGameType == null)
        {
            Debug.LogError("[DemoSceneCreator] DemoGame component type not found.");
            return;
        }

        // Ensure folder exists (create recursively if needed)
        EnsureFolderExists(SceneFolder);

        // Create a new untitled scene
        var newScene = EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects, NewSceneMode.Single);
        newScene.name = SceneName;

        // Create the root object and add DemoGame
        var root = new GameObject(RootObjectName);
        root.AddComponent(demoGameType);
        SceneManager.MoveGameObjectToScene(root, newScene);

        // Save scene to disk
        string assetPath = Path.Combine(SceneFolder, SceneName + ".unity").Replace("\\", "/");
        bool ok = EditorSceneManager.SaveScene(newScene, assetPath, true);
        if (!ok)
        {
            Debug.LogError("[DemoSceneCreator] Failed to save scene.");
            return;
        }

        AssetDatabase.Refresh();

        // Ping/select the new scene asset
        var sceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(assetPath);
        if (sceneAsset != null)
        {
            EditorGUIUtility.PingObject(sceneAsset);
            Selection.activeObject = sceneAsset;
        }

        Debug.Log($"[DemoSceneCreator] Created scene at: {assetPath}");
    }

    private static void EnsureFolderExists(string folderPath)
    {
        if (AssetDatabase.IsValidFolder(folderPath)) return;

        // Create nested folders as needed (e.g., Assets/Scenes/Sub)
        string[] parts = folderPath.Split('/');
        string current = parts[0]; // typically "Assets"
        for (int i = 1; i < parts.Length; i++)
        {
            string next = $"{current}/{parts[i]}";
            if (!AssetDatabase.IsValidFolder(next))
            {
                AssetDatabase.CreateFolder(current, parts[i]);
            }
            current = next;
        }
    }
}
#endif
