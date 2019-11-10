using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static UIManager instance;
    [SerializeField]
    TextMeshProUGUI Killcounter_TMP;
    [HideInInspector]
    public int killcount;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    // Update is called once per frame
    public void UpdateKillcounterUI()
    {
        Killcounter_TMP.text = killcount.ToString();
    }
}
