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

    public GameObject shooterNozzle;
    [Range(-20f, 20f)] public float xAngle = 0f;
    //[Range(-68f, 68f)] public float yAngle = 0f;
    [Range(-20f, 20f)] public float zAngle = 0f;


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

        GameObject singleProjectile = newProjectile.transform.Find("Projectile").gameObject;
        singleProjectile.GetComponent<Rigidbody>().AddForce(directionWithoutSpread.normalized * shootForce, ForceMode.Impulse);

        while(singleProjectile != null && (singleProjectile.transform.localPosition.x <= maxDistance && singleProjectile.transform.localPosition.y <= maxDistance && singleProjectile.transform.localPosition.x <= maxDistance)){
            yield return null;
        }

        Destroy(newProjectile);
        

        //newProjectile.transform.SetParent(projectilePrefab.transform.parent);
        //newProjectile.transform.localPosition = Vector3.zero;

        /* GameObject newBeam = newProjectile.transform.Find("Projectile").gameObject;
        //newBeam.transform.localRotation = Quaternion.identity;
        newProjectile.SetActive(true);

        Vector3 startPos = newBeam.transform.localPosition;
        Vector3 endPosition = target.transform.localPosition;

        while(newBeam != null){
            //newProjectile.transform.localPosition += new Vector3(0f, 2f * Time.deltaTime, 0f);
            newBeam.transform.localPosition = Vector3.Lerp(startPos, endPosition, 2f * Time.deltaTime);
            newBeam.transform.localRotation = Quaternion.LookRotation(endPosition);
            yield return null;
        } */
    }
}
