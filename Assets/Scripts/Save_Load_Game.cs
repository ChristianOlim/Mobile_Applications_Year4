using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
    

public class Save_Load_Game : MonoBehaviour
{
    public static Save_Load_Game saveLoadGame;
    public int totalScore;

    private void Awake()
    {

        if(saveLoadGame == null){
            DontDestroyOnLoad(gameObject);
            saveLoadGame = this;
        }
        else if (saveLoadGame!= this)
        {
            Destroy(gameObject);
        }
    }

    public void SaveOption()
    {
        // This creates a binary formatter
        BinaryFormatter BinForm = new BinaryFormatter();

        // This creates a file
        FileStream file = File.Create(Application.persistentDataPath + "/gameInformation.dat");

        // This creates a container for the information
        gameInfo info = new gameInfo();
        info.totalscore = totalScore;
        BinForm.Serialize(file, info);
        file.Close();
    }

    public void LoadOption()
    {
        if (File.Exists(Application.persistentDataPath + "gameInformation.dat"))
        {
            BinaryFormatter BinForm = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gameInformation.dat", FileMode.Open);
            // This will decrypt the binary
            gameInfo info = (gameInfo)BinForm.Deserialize(file);
            file.Close();
            totalScore = info.totalscore;
        }
    }
}

[Serializable]
class gameInfo
{
    public int totalscore;
}
