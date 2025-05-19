using System;
using System.Collections;
using Unity.Collections;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public enum EnemyType
{
    None,
    Offensive,
    Defensive
}

public class Enemy : MonoBehaviour
{
    public EnemyType defenderType;
    public GameObject projectilePrefab;
    public Transform target;
    public float shootForce = 5f;
    public float maxDistance = 20f;
    public float maxHealth = 10;
    public float currHealth = 10;

    public Slider slider;

    public GameObject shooterNozzle;
    [Range(-20f, 20f)] public float xAngle = 0f;
    //[Range(-68f, 68f)] public float yAngle = 0f;
    [Range(-20f, 20f)] public float zAngle = 0f;


    void OnEnable(){
        projectilePrefab.SetActive(false);
        currHealth = maxHealth;
        //StartCoroutine(MultipleProjectiles(100));
    }

    void OnTriggerEnter(Collider other){
        Destroy(other.gameObject);
        currHealth--;
        slider.value = currHealth / maxHealth;

        if(currHealth <= 0){
            Destroy(gameObject);
        }
    }

    /* void Update(){
        shooterNozzle.transform.localEulerAngles = new Vector3(xAngle, 0f, zAngle);
    } */

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
    }
}
