using System.Collections.Generic;
using System.IO;
using Data;
using UnityEngine;

namespace Managers
{
    public class SaveManager
    {
        private static SaveManager _instance;
        public static SaveManager Instance => _instance ??= new SaveManager();

        private static string SaveFilePath => Path.Combine(Application.persistentDataPath, "save_data.txt");
        private SaveData saveData;

        private SaveManager()
        {
            Load();

            // If no save data exists, create a new one
            if (saveData == null)
                CreateNewSaveData();
        }

        private void CreateNewSaveData()
        {
            saveData = new SaveData(System.Guid.NewGuid().ToString());
            Save();
        }

        public void Save()
        {
            string jsonSaveData = JsonUtility.ToJson(saveData, true);
            string encryptedText = EncryptionHelper.Encrypt(jsonSaveData);
            File.WriteAllText(SaveFilePath, encryptedText);

            Debug.Log($"Saved to: {SaveFilePath}");
        }

        public void SaveGameData(IGameSaveData gameSaveData)
        {
            string gameSave;
            // TODO get type of game save
            //saveData.gameProgress.
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

        public SaveData GetSaveData() => saveData;
        public void SetSaveData(SaveData newData)
        {
            saveData = newData;
            Save();
        }
    }
}
