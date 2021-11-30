using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class JsonSave : MonoBehaviour
{
    private SaveData saveData = new SaveData();

    private string SAVE_DATA_DIRECTORY;  // ������ ���� ���
    private string SAVE_FILENAME = "/SaveFile.txt"; // ���� �̸�

    void Start()
    {
        SAVE_DATA_DIRECTORY = Application.dataPath + "/Save/";

        if (!Directory.Exists(SAVE_DATA_DIRECTORY)) // �ش� ��ΰ� �������� �ʴ´ٸ�
            Directory.CreateDirectory(SAVE_DATA_DIRECTORY); // ���� ����(��� ����)
    }

    public void Save()
    {
        Debug.Log("���̺�");
        Debug.Log(GameManager.Instance.repeatTime);
        Debug.Log("/");


        saveData.saveRepeatTime = GameManager.Instance.repeatTime;
        // repeatTime���� 

        // ���� ��ü ����
        string json = JsonUtility.ToJson(saveData); // ���̽�ȭ

        File.WriteAllText(SAVE_DATA_DIRECTORY + SAVE_FILENAME, json);

        Debug.Log("���� �Ϸ�");
        Debug.Log(json);
    }

    public void Load()
    {
        Debug.Log("�ε�");
        Debug.Log(" / ");

        if (File.Exists(SAVE_DATA_DIRECTORY + SAVE_FILENAME))
        {
            // ��ü �о����
            string loadJson = File.ReadAllText(SAVE_DATA_DIRECTORY + SAVE_FILENAME);
            saveData = JsonUtility.FromJson<SaveData>(loadJson);

            GameManager.Instance.repeatTime = saveData.saveRepeatTime;

            Debug.Log(GameManager.Instance.repeatTime);
            Debug.Log("�ε� �Ϸ�");

            GameManager.Instance.LoadStage();
        }
        else
        {
            Debug.Log("���̺� ������ �����ϴ�.");
        }
    }
}
