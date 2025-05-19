using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.XR.Interaction;

public enum CubeSide
{
    None,
    Side1,
    Side2,
    Side3,
    Side4,
    Side5,
    Side6
}

public class TileLocation : MonoBehaviour
{
    public GameObject spawnArea;
    public GameObject activeFlag;
    public GameObject setCharacterLocation;
    public bool locationActiveState = false;
    public CubeSide cubeSide;
    public bool playerCanSpawn = false;

    public List<GameObject> characters;

    void Start(){
        activeFlag.SetActive(false);
    }

    public void LocationSelected(){
        locationActiveState = !locationActiveState;
        activeFlag.SetActive(locationActiveState);
    }

    public void RotatePlayerOnTeleport(){
        switch(cubeSide){
            case CubeSide.Side1:
                PlayerManager.instance.gameObject.transform.eulerAngles = new Vector3(0f, 0f, 0f);
                break;
            case CubeSide.Side2:
                PlayerManager.instance.gameObject.transform.eulerAngles = new Vector3(-90f, 0f, 0f);
                break;
            case CubeSide.Side3:
                PlayerManager.instance.gameObject.transform.eulerAngles = new Vector3(0f, 0f, 90f);
                break;
            case CubeSide.Side4:
                PlayerManager.instance.gameObject.transform.eulerAngles = new Vector3(0f, 0f, 180f);
                break;
            case CubeSide.Side5:
                PlayerManager.instance.gameObject.transform.eulerAngles = new Vector3(-90f, 180f, 0f);
                break;
            case CubeSide.Side6:
                PlayerManager.instance.gameObject.transform.eulerAngles = new Vector3(0f, 0f, -90f);
                break;
        }
    }

    
}
