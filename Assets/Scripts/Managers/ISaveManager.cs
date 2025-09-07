
using GFrame.Data;

namespace GFrame.Managers
{
    public interface ISaveManager
    {
        void CreateNewSave();
        void Save();
        void Save(string gameID, IGameSaveData gameSaveData);
        void Load();
    }
}
