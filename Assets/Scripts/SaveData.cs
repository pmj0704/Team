using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int saveRepeatTime;
    public bool savecurrentSound;
    public bool savecurrentTv;
    // [System.Serializable] > 직렬화의 이유 : 
    // Json 은 직렬화 하여 저장되는 포맷이므로 인수로 넘긴 객체는 직렬화 가능한 객체여야 한다.
    // SaveData 는 직렬화한 클래스라 가능
}