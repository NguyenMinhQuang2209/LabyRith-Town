using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManagement : MonoBehaviour
{
    public static Vector2 lastCheckPointPos = new Vector2((float)-17.86024, (float)-2.334611);
    public GameObject[] playerPrefabs;
    int characterIndex;
    public CinemachineVirtualCamera Vcam;

    private void Awake()
    {
        
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        GameObject Player = Instantiate(playerPrefabs[characterIndex], lastCheckPointPos, Quaternion.identity);
        Vcam.m_Follow = Player.transform;
    }
}
