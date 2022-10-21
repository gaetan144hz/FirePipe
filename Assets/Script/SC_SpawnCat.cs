using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SC_SpawnCat : MonoBehaviour
{
    [Header("Spawn")]
    public Transform[] spawnPoint;
    public GameObject[] man;
    public SC_Timer time;
    public static bool spawnAllowedl;
    
    private int randomSpawnPoint, randomMan;
    
    [Header("Rate")]
    [SerializeField] private float repeatRate;
    [SerializeField] private float decreaseRepeatRate;

    private List<bool> listSpawnPoint = new List<bool>();

    void Start()
    {
        for (int i = 0; i < spawnPoint.Length; i++)
        {
            listSpawnPoint.Add(true);
        }

        StartCoroutine(startSpawn());
        //InvokeRepeating("Spawn01",10 ,repeatRate);
    }

    void Update()
    {
        if (time.sec >= 60)
        {
            repeatRate -= decreaseRepeatRate;
        }

        if (repeatRate <= 0.4f)
        {
            repeatRate = 0.5f;
        }
    }

    IEnumerator startSpawn()
    {
        yield return new WaitForSeconds(30f);
        while (true)
        {
            Spawn01();
            yield return new WaitForSeconds(repeatRate);
        }
    }

    public void Spawn01()
    {
        List<int> tmpListSP = new List<int>();
        
        for (int i = 0; i < listSpawnPoint.Count; i++)
        {
            if (listSpawnPoint[i] == true)
            {
                tmpListSP.Add(i);
            }
        }
        
        if (tmpListSP.Count > 0)
        {
            randomSpawnPoint = Random.Range(0, tmpListSP.Count);
            randomMan = Random.Range(0, man.Length);
            GameObject tmpGO = Instantiate(man[randomMan], spawnPoint[tmpListSP[randomSpawnPoint]].position, Quaternion.identity);
            tmpGO.GetComponent<SC_Cat>().index = tmpListSP[randomSpawnPoint];
            tmpGO.GetComponent<SC_Cat>().spawn = this;
            listSpawnPoint[tmpListSP[randomSpawnPoint]] = false;
        }
    }

    public void ResetSpawnPoint(int index)
    {
        listSpawnPoint[index] = true;
    }
    /*
        foreach(Transform point in spawnPoint)
        {
            Destroy(this.gameObject);
        }
    */
}