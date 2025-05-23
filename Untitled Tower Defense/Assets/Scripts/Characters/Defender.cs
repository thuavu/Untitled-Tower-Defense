using System;
using System.Collections;
using Unity.Collections;
using UnityEngine;
using UnityEditor;

public enum DefenderType
{
    None,
    Offensive,
    Defensive
}

public class Defender : MonoBehaviour
{
    public DefenderType defenderType;
    public GameObject projectilePrefab;
    public Transform target;
    public float shootForce = 5f;
    public float maxDistance = 20f;

    public bool isEnableAwake = false;

    public GameObject shooterNozzle;
    [Range(-20f, 20f)] public float xAngle = 0f;
    //[Range(-68f, 68f)] public float yAngle = 0f;
    [Range(-20f, 20f)] public float zAngle = 0f;

    /* void Awake(){
        gameObject.SetActive(isEnableAwake);
    } */

    void OnEnable(){
        projectilePrefab.SetActive(false);
        StartCoroutine(MultipleProjectiles(100));
    }

    void Update(){
        shooterNozzle.transform.localEulerAngles = new Vector3(xAngle, 0f, zAngle);
    }

    public IEnumerator MultipleProjectiles(int numProjectiles){
        int currNum = 0;
        while(currNum < numProjectiles){
            StartCoroutine(FireProjectile());
            currNum++;
            yield return new WaitForSeconds(1f);
        }
    }
    
    public IEnumerator FireProjectile(){    
        Vector3 directionWithoutSpread = target.position - projectilePrefab.transform.position;

        GameObject newProjectile = Instantiate(projectilePrefab, projectilePrefab.transform.position, Quaternion.identity);
        newProjectile.transform.SetParent(shooterNozzle.transform.parent);
        newProjectile.transform.rotation = shooterNozzle.transform.rotation;
        newProjectile.SetActive(true);
        newProjectile.GetComponent<Rigidbody>().AddForce(directionWithoutSpread.normalized * shootForce, ForceMode.Impulse);

        while(newProjectile != null && (newProjectile.transform.localPosition.x <= maxDistance && newProjectile.transform.localPosition.y <= maxDistance && newProjectile.transform.localPosition.x <= maxDistance)){
            yield return null;
        }

        Destroy(newProjectile);
    }
}
