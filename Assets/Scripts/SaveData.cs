using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int saveRepeatTime;
    public bool savecurrentSound;
    public bool savecurrentTv;
    // [System.Serializable] > ����ȭ�� ���� : 
    // Json �� ����ȭ �Ͽ� ����Ǵ� �����̹Ƿ� �μ��� �ѱ� ��ü�� ����ȭ ������ ��ü���� �Ѵ�.
    // SaveData �� ����ȭ�� Ŭ������ ����
}