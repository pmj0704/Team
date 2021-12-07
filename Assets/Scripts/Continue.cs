using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Continue : MonoBehaviour
{
    private int saves = 0;
    [SerializeField]
    private GameObject Esc;
    [SerializeField]
   // private GameObject bts;
    //[SerializeField]
    private Text ErrorText;
    [SerializeField]
    //private GameObject NewGameObj;
    //[SerializeField]
    private GameObject MainMenu;
    [SerializeField]
    private GameObject Settings;
    private int num = 1;
    [SerializeField]
    private GameObject NewGameMsg;
    public void Contiune()
    {
        Esc.SetActive(false);
        Time.timeScale = 1;
        GameManager.Instance.Resume();
        GameManager.Instance.uiOn = false;
        Cursor.visible = false;
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void NewGameBt()
    {
        NewGameMsg.SetActive(true);
    }
    public void BackMenu()
    {
        NewGameMsg.SetActive(false);
    }
    public void NewGame()
    {
        //if(saves < 3)
        //{
        //    bts.SetActive(false);
        //    NewGameObj.SetActive(true);
        //}
        //else
        //{
        //    ErrorText.text = "You can only save maximum 3 save files";
        //    StartCoroutine(Error(ErrorText.gameObject));
        //}
        Time.timeScale = 1;
        GameManager.Instance.hasKey = false;
        GameManager.Instance.Resume();
        GameManager.Instance.Started = true;
        GameManager.Instance.StartGame();
        GameManager.Instance.repeatTime = -1;
        GameManager.Instance.NextStage();
        GameManager.Instance.jsonSave.Save();
        Cursor.visible = false;
        GameManager.Instance.mainOn = false;
        MainMenu.SetActive(false);
        Esc.SetActive(false);
        NewGameMsg.SetActive(false);
    }
    public void LoadGame()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        GameManager.Instance.hasKey = false;
        GameManager.Instance.RespawnF();
        GameManager.Instance.RespawnTrue();
        GameManager.Instance.Resume();
        GameManager.Instance.Started = true;
        GameManager.Instance.StartGame();
        GameManager.Instance.jsonSave.Load();
        GameManager.Instance.mainOn = false;
        MainMenu.SetActive(false);
        Esc.SetActive(false);
    }
    private IEnumerator Error(GameObject game)
    {
        game.SetActive(true);
        yield return new WaitForSeconds(2f);
        game.SetActive(true);
    }
    public void Back()
    {
        Settings.SetActive(false);
        if(num == 1)
        {
            GameManager.Instance.mainOn = true;
            MainMenu.SetActive(true);
        }
        else if(num == 2)
        {
            Esc.SetActive(true);
        }
    }
    public void SettingsF(int i)
    {
        GameManager.Instance.mainOn = false;
        MainMenu.SetActive(false);
        Esc.SetActive(false);
        Settings.SetActive(true);
        num = i;
    }
    public void Create()
    {
        saves++;
        Cursor.visible = false;
    }
    public void MainMenuF()
    {
        Esc.SetActive(false);
            GameManager.Instance.mainOn = true;
        MainMenu.SetActive(true);
    }
}
