using System.IO;
using GFrame.Data;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GFrame.Managers
{
    public class SaveManager : MonoBehaviour, ISaveManager
    {
        [SerializeField] private string playerID = "default-player";
        private static string SaveFilePath => Path.Combine(Application.persistentDataPath, "save_data.txt");
        private SaveData saveData;
        public SaveData SaveData => saveData;

        public void Start()
        {
            Load();

            // If no save data exists, create a new one
            if (saveData == null)
                CreateNewSave();
        }

        public void Save()
        {
            string jsonSaveData = JsonUtility.ToJson(saveData, true);
            string encryptedText = EncryptionHelper.Encrypt(jsonSaveData);
            File.WriteAllText(SaveFilePath, encryptedText);

            Debug.Log($"Saved to: {SaveFilePath}");
        }

        public void Save(string gameID, IGameSaveData gameSaveData)
        {
            if(saveData.gameProgress.TryGetValue(gameID, out IGameSaveData existingSave))
            {
                // overwrite
                saveData.gameProgress[gameID] = gameSaveData;
                return;
            }

            saveData.gameProgress.Add(gameID, gameSaveData);
            Save();
        }

        public void Load()
        {
            if (!File.Exists(SaveFilePath))
            {
                Debug.LogWarning("Save file not found. No data loaded.");
                return;
            }

            string encryptedFileContent = File.ReadAllText(SaveFilePath);
            string decryptedJson = EncryptionHelper.Decrypt(encryptedFileContent);
            saveData = JsonUtility.FromJson<SaveData>(decryptedJson);

            Debug.Log("Save data loaded.");
        }

        public void CreateNewSave()
        {
            saveData = new SaveData(playerID);
            Save();
        }

#if UNITY_EDITOR
        [Button]
        private void ClearSaveData()
        {
            Debug.Log("Deleting Save File");
            File.Delete(SaveFilePath);
        }
#endif
    }
}
