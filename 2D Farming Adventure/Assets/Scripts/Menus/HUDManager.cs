using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public TextMeshProUGUI time;
    public GameObject GameUI;
    private void Start()
    {
        time = GameObject.Find("Time").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
      // time.text = UniStormSystem.Instance.Hour.ToString() + ":" + UniStormSystem.Instance.Minute.ToString();
    }
}
