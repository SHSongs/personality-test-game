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
    }
 
    public void close()
    {
        Menual.SetActive(false);
    }
    IEnumerator Example() {
        print(Time.time);
        yield return new WaitForSeconds(5);
        print(Time.time);
    }
}
