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

        //������ ������ 2��ȭ
        BinaryFormatter formatter = new BinaryFormatter();
        //������ ���Ͽ� ����
        FileStream fs = new FileStream(path, FileMode.Create);

        //������ ������ �غ�
        PlayData playData = new PlayData();        

        //������(playData)�� 2��ȭ�ؼ� ���Ͽ� ����
        formatter.Serialize(fs, playData);
        
        fs.Close();
    }

    public static PlayData LoadData()
    {
        string path = Application.persistentDataPath + "/pDat.arr";

        //������ ��ο� ������ ������ �ִ��� ������ üũ
        if(File.Exists(path))
        {
            //������ ������ ��2��ȭ
            BinaryFormatter formatter = new BinaryFormatter();
            //������ ���Ͽ� ����
            FileStream fs = new FileStream(path, FileMode.Open);

            //���Ͽ� ����� ������(playData)�� ��2��ȭ�ؼ� �����´�
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
