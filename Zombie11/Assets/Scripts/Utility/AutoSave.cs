using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoSave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //����ȣ ����
        AutoSaveData();
    }

    private void AutoSaveData()
    {
        PlayerStats.instance.sceneNum = SceneManager.GetActiveScene().buildIndex;
        SaveLoad.SaveData();
    }
}
