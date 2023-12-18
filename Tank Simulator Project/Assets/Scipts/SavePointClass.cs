using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SavePointClass : MonoBehaviour
{
    public class SaveData
    {
        public int savedSceneId;
    }

    private string saveFile = "/saveData.json";
    private SaveData saveData;

    public bool WriteData(string fileName)
    {
        Debug.Log("Saving data to " + fileName);
        try
        {
            File.WriteAllText(fileName + saveFile, JsonUtility.ToJson(saveData));
            return true;
        }
        catch
        {
            return false;
        }
    }

    private bool LoadData(string fileName)
    {
        Debug.Log("Loading data from " + fileName);
        if (File.Exists(fileName))
        {
            JsonUtility.FromJsonOverwrite(File.ReadAllText(fileName), saveData);
            return true;
        }
        else
        {
            Debug.Log("Error: File does not exist");
            return false;
        }
    }

    public int getSaveScreenId()
    {
        return saveData.savedSceneId;
    }

    public bool setSaveScreenId(int id, string fileName)
    {
        // save
        if (WriteData(fileName))
        {
            saveData.savedSceneId = id;
            return true;
        }
        else
            return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        string fileName = Application.persistentDataPath + saveFile;
        saveData = new SaveData();
        LoadData(fileName);
    }
}
