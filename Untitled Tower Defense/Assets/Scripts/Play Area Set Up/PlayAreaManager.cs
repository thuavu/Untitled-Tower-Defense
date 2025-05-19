using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayAreaManager : MonoBehaviour
{
    public GameObject spawnLocationPrefab;
    public int playAreaSize = 8;

    // For Debug purposes
    public int numberOfDefenders = 50;

    void Start(){
        SpawnPlayerAreaCenter();
        //SpawnDefenderAtRandomLocation();
    }

    public void SpawnPlayerAreaCenter(){
        // Player Area
        int topBottomSides = playAreaSize * 2 + 1;
        for(int i = 0; i < topBottomSides; i++){
            for(int j = -playAreaSize; j <= playAreaSize; j++){
                for(int k = -playAreaSize; k <= playAreaSize; k++){
                    // Top Side
                    if(i == 0){
                        GameObject newLocation = Instantiate(spawnLocationPrefab);
                        newLocation.transform.SetParent(spawnLocationPrefab.transform.parent);
                        newLocation.transform.localPosition = new Vector3(k, -i, j);
                        newLocation.GetComponent<TileLocation>().cubeSide = CubeSide.Side1;
                        newLocation.SetActive(true);

                        if(Mathf.Abs(k) == 0 && Mathf.Abs(j) == 0){
                            newLocation.GetComponent<TileLocation>().spawnArea.GetComponent<Renderer>().materials[0].SetColor("_BaseColor", Color.orange);
                            newLocation.GetComponent<TileLocation>().playerCanSpawn = true;
                        }
                    }
                    // Side 2
                    if(j == -playAreaSize){
                        GameObject newLocation = Instantiate(spawnLocationPrefab);
                        newLocation.transform.SetParent(spawnLocationPrefab.transform.parent);
                        newLocation.transform.localPosition = new Vector3(k, -i, j);
                        newLocation.transform.Rotate(-90, 0, 0);
                        newLocation.GetComponent<TileLocation>().cubeSide = CubeSide.Side2;
                        newLocation.SetActive(true);

                        if(Mathf.Abs(k) == 0 && Mathf.Abs(i) == playAreaSize){
                            newLocation.GetComponent<TileLocation>().spawnArea.GetComponent<Renderer>().materials[0].SetColor("_BaseColor", Color.orange);
                            newLocation.GetComponent<TileLocation>().playerCanSpawn = true;
                        }
                    }
                    // Side 3
                    if(k == -playAreaSize){
                        GameObject newLocation = Instantiate(spawnLocationPrefab);
                        newLocation.transform.SetParent(spawnLocationPrefab.transform.parent);
                        newLocation.transform.localPosition = new Vector3(k, -i, j);
                        newLocation.transform.Rotate(0, 0, 90);
                        newLocation.GetComponent<TileLocation>().cubeSide = CubeSide.Side3;
                        newLocation.SetActive(true);

                        if(Mathf.Abs(i) == playAreaSize && Mathf.Abs(j) == 0){
                            newLocation.GetComponent<TileLocation>().spawnArea.GetComponent<Renderer>().materials[0].SetColor("_BaseColor", Color.orange);
                            newLocation.GetComponent<TileLocation>().playerCanSpawn = true;
                        }
                    }
                    // Bottom
                    if(i == topBottomSides - 1){
                        GameObject newLocation = Instantiate(spawnLocationPrefab);
                        newLocation.transform.SetParent(spawnLocationPrefab.transform.parent);
                        newLocation.transform.localPosition = new Vector3(-k, -i, -j);
                        newLocation.transform.Rotate(0, 0, 180);
                        newLocation.GetComponent<TileLocation>().cubeSide = CubeSide.Side4;
                        newLocation.SetActive(true);

                        if(Mathf.Abs(k) == 0 && Mathf.Abs(j) == 0){
                            newLocation.GetComponent<TileLocation>().spawnArea.GetComponent<Renderer>().materials[0].SetColor("_BaseColor", Color.orange);
                            newLocation.GetComponent<TileLocation>().playerCanSpawn = true;
                        }
                    }
                    // Side 5
                    if(j == playAreaSize){
                        GameObject newLocation = Instantiate(spawnLocationPrefab);
                        newLocation.transform.SetParent(spawnLocationPrefab.transform.parent);
                        newLocation.transform.localPosition = new Vector3(k, -i, j);
                        newLocation.transform.Rotate(-90, 180, 0);
                        newLocation.GetComponent<TileLocation>().cubeSide = CubeSide.Side5;
                        newLocation.SetActive(true);

                        if(Mathf.Abs(k) == 0 && Mathf.Abs(i) == playAreaSize){
                            newLocation.GetComponent<TileLocation>().spawnArea.GetComponent<Renderer>().materials[0].SetColor("_BaseColor", Color.orange);
                            newLocation.GetComponent<TileLocation>().playerCanSpawn = true;
                        }
                    }
                    // Side 6
                    if(k == playAreaSize){
                        GameObject newLocation = Instantiate(spawnLocationPrefab);
                        newLocation.transform.SetParent(spawnLocationPrefab.transform.parent);
                        newLocation.transform.localPosition = new Vector3(k, -i, j);
                        newLocation.transform.Rotate(0, 0, -90);
                        newLocation.GetComponent<TileLocation>().cubeSide = CubeSide.Side6;
                        newLocation.SetActive(true);

                        if(Mathf.Abs(i) == playAreaSize && Mathf.Abs(j) == 0){
                            newLocation.GetComponent<TileLocation>().spawnArea.GetComponent<Renderer>().materials[0].SetColor("_BaseColor", Color.orange);
                            newLocation.GetComponent<TileLocation>().playerCanSpawn = true;
                        }
                    }



                    /* if(i == 0 || j == 0 || k == 0 || i == playAreaSize - 1 || j == playAreaSize - 1 || k == playAreaSize - 1 ){
                        GameObject newLocation = Instantiate(spawnLocationPrefab);
                        newLocation.transform.SetParent(spawnLocationPrefab.transform.parent);
                        newLocation.transform.localPosition = new Vector3(-k, -i, -j);
                        newLocation.SetActive(true);
                    } */
                }
            }
        }
        spawnLocationPrefab.SetActive(false);
    }

    // Spawn Player Area from Top Corner
    /* public void SpawnPlayerArea(){
        // Player Area
        for(int i = 0; i < playAreaSize; i++){
            for(int j = 0; j < playAreaSize; j++){
                for(int k = 0; k < playAreaSize; k++){
                    // Top Side
                    if(i == 0){
                        GameObject newLocation = Instantiate(spawnLocationPrefab);
                        newLocation.transform.SetParent(spawnLocationPrefab.transform.parent);
                        newLocation.transform.localPosition = new Vector3(-k, -i, -j);
                        newLocation.GetComponent<TileLocation>().cubeSide = CubeSide.Side1;
                        newLocation.SetActive(true);
                    }
                    // Side 2
                    if(j == 0){
                        GameObject newLocation = Instantiate(spawnLocationPrefab);
                        newLocation.transform.SetParent(spawnLocationPrefab.transform.parent);
                        newLocation.transform.localPosition = new Vector3(-k, -i, -j);
                        newLocation.transform.Rotate(-90, 0, 0);
                        newLocation.GetComponent<TileLocation>().cubeSide = CubeSide.Side2;
                        newLocation.SetActive(true);
                    }
                    // Side 3
                    if(k == 0){
                        GameObject newLocation = Instantiate(spawnLocationPrefab);
                        newLocation.transform.SetParent(spawnLocationPrefab.transform.parent);
                        newLocation.transform.localPosition = new Vector3(-k, -i, -j);
                        newLocation.transform.Rotate(0, 0, 90);
                        newLocation.GetComponent<TileLocation>().cubeSide = CubeSide.Side3;
                        newLocation.SetActive(true);
                    }
                    // Bottom
                    if(i == playAreaSize - 1){
                        GameObject newLocation = Instantiate(spawnLocationPrefab);
                        newLocation.transform.SetParent(spawnLocationPrefab.transform.parent);
                        newLocation.transform.localPosition = new Vector3(-k, -i, -j);
                        newLocation.transform.Rotate(0, 0, 180);
                        newLocation.GetComponent<TileLocation>().cubeSide = CubeSide.Side4;
                        newLocation.SetActive(true);
                    }
                    // Side 5
                    if(j == playAreaSize - 1){
                        GameObject newLocation = Instantiate(spawnLocationPrefab);
                        newLocation.transform.SetParent(spawnLocationPrefab.transform.parent);
                        newLocation.transform.localPosition = new Vector3(-k, -i, -j);
                        newLocation.transform.Rotate(-90, 180, 0);
                        newLocation.GetComponent<TileLocation>().cubeSide = CubeSide.Side5;
                        newLocation.SetActive(true);
                    }
                    // Side 5
                    if(k == playAreaSize - 1){
                        GameObject newLocation = Instantiate(spawnLocationPrefab);
                        newLocation.transform.SetParent(spawnLocationPrefab.transform.parent);
                        newLocation.transform.localPosition = new Vector3(-k, -i, -j);
                        newLocation.transform.Rotate(0, 0, -90);
                        newLocation.GetComponent<TileLocation>().cubeSide = CubeSide.Side6;
                        newLocation.SetActive(true);
                    }
                }
            }
        }
        spawnLocationPrefab.SetActive(false);
    } */

    public void SpawnDefenderAtRandomLocation(){
        int counter = 0;
        TileLocation[] allTiles = FindObjectsOfType<TileLocation>();
        Debug.Log($"Count of allTiles: {allTiles.Length}");
        while(counter < numberOfDefenders){
            allTiles[Random.Range(0, allTiles.Length-1)].characters[0].SetActive(true);
            counter++;
        }
    }

}
