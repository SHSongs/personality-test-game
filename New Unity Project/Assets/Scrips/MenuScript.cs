using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject Menual;
    
    public void MapChange()
    {
        SceneManager.LoadScene("Main");
    }
    
    public void Help()
    { 
        Menual.SetActive(true);
        StartCoroutine("Example");
    }
 
    public void close()
    {
        Menual.SetActive(false);
    }
    IEnumerator Example() {
        print(Time.time);
        yield return new WaitForSeconds(1);
        Menual.SetActive(false);

        print(Time.time);
    }

    public void KingMode()
    {
        SceneManager.LoadScene("M2");
        
    }
}
