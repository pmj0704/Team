using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class JsonSave : MonoBehaviour
{
    private SaveData saveData = new SaveData();

    private string SAVE_DATA_DIRECTORY;  // 저장할 폴더 경로
    private string SAVE_FILENAME = "/SaveFile.txt"; // 파일 이름

    void Start()
    {
        SAVE_DATA_DIRECTORY = Application.dataPath + "/Save/";

        if (!Directory.Exists(SAVE_DATA_DIRECTORY)) // 해당 경로가 존재하지 않는다면
            Directory.CreateDirectory(SAVE_DATA_DIRECTORY); // 폴더 생성(경로 생성)
    }

    public void Save()
    {
        Debug.Log("세이브");
        Debug.Log(GameManager.Instance.repeatTime);
        Debug.Log("/");


        saveData.saveRepeatTime = GameManager.Instance.repeatTime;
        // repeatTime저장 

        // 최종 전체 저장
        string json = JsonUtility.ToJson(saveData); // 제이슨화

        File.WriteAllText(SAVE_DATA_DIRECTORY + SAVE_FILENAME, json);

        Debug.Log("저장 완료");
        Debug.Log(json);
    }

    public void Load()
    {
        Debug.Log("로드");
        Debug.Log(" / ");

        if (File.Exists(SAVE_DATA_DIRECTORY + SAVE_FILENAME))
        {
            // 전체 읽어오기
            string loadJson = File.ReadAllText(SAVE_DATA_DIRECTORY + SAVE_FILENAME);
            saveData = JsonUtility.FromJson<SaveData>(loadJson);

            GameManager.Instance.repeatTime = saveData.saveRepeatTime;

            Debug.Log(GameManager.Instance.repeatTime);
            Debug.Log("로드 완료");

            GameManager.Instance.LoadStage();
        }
        else
        {
            Debug.Log("세이브 파일이 없습니다.");
        }
    }
}
