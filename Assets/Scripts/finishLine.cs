using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finishLine : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isEnd;
    public GameObject youWin;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter()
    {
        if(isEnd == false)
        {
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	else
	{
	   youWin.SetActive(true);
	}
    }
}
