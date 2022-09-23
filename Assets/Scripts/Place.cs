using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Place : MonoBehaviour
{
    List<GameObject> canvasList = new List<GameObject>();
    int i;
    public GameObject canvas;
    public GameObject twr;
    bool a = true;

    // Start is called before the first frame update
    void Start()
    {
        canvasList = GameObject.FindGameObjectsWithTag("PlaceCanvas").ToList();
        // for (i = 0; i < canvasList.Count; i++) if (canvasList[i].name == name) canvas = canvasList[i];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        for (i = 0; i < canvasList.Count; i++) canvasList[i].SetActive(false);
        canvas.SetActive(true);

        if (a) 
        {
            GameObject tower = GameObject.Instantiate(twr, transform.position, Quaternion.identity) as GameObject;
            a = false;
        }
        
    }
}
