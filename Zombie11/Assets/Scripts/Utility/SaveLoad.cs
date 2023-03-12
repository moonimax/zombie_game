using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveLoad
{
    public static void SaveData()
    {
        string path = Application.persistentDataPath + "/pDat.arr";

        //저장할 데이터 2진화
        BinaryFormatter formatter = new BinaryFormatter();
        //저장할 파일에 접근
        FileStream fs = new FileStream(path, FileMode.Create);

        //저장할 데이터 준비
        PlayData playData = new PlayData();        

        //데이터(playData)를 2진화해서 파일에 저장
        formatter.Serialize(fs, playData);
        
        fs.Close();
    }

    public static PlayData LoadData()
    {
        string path = Application.persistentDataPath + "/pDat.arr";

        //지정된 경로에 지정된 파일이 있는지 없는지 체크
        if(File.Exists(path))
        {
            //가져올 데이터 역2진화
            BinaryFormatter formatter = new BinaryFormatter();
            //저장할 파일에 접근
            FileStream fs = new FileStream(path, FileMode.Open);

            //파일에 저장된 데이터(playData)를 역2진화해서 가져온다
            PlayData playData = formatter.Deserialize(fs) as PlayData;
            
            fs.Close();

            return playData;
        }
        else
        {
            return null;
        }
    }
}
