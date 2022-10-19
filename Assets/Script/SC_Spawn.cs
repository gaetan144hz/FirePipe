using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SC_Spawn : MonoBehaviour
{
    [Header("Spawn")]
    public Transform[] spawnPoint;
    public GameObject[] man;
    public static bool spawnAllowedl;
    
    private int randomSpawnPoint, randomMan;
    
    [Header("Rate")]
    [SerializeField] private float repeatRate;
    [SerializeField] private float time;

    private List<bool> listSpawnPoint = new List<bool>();

    void Start()
    {
        for (int i = 0; i < spawnPoint.Length; i++)
        {
            listSpawnPoint.Add(true);
        }
        
        InvokeRepeating("Spawn01",1 ,repeatRate);
    }

    void Update()
    {
        
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
            tmpGO.GetComponent<SC_Homme>().index = tmpListSP[randomSpawnPoint];
            tmpGO.GetComponent<SC_Homme>().spawn = this;
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
