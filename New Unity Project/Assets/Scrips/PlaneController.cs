using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlaneController : MonoBehaviour
{
    bool ready = true;
    [FormerlySerializedAs("Text")] public Text text;

    public Text success;

    private float _timer = 0;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    private float delta = 3;
    
    private int _inputMethod = 0;
    private int _cnt = 0;
    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        float z = Input.GetAxis("Mouse ScrollWheel");
        x *= 5;
        y *= 5;
        z *= 5*10;

        
        if (_timer > delta)
        {
            delta = Random.Range(1.0f, 3.0f);
            print(delta);
            _inputMethod++;
            _timer = 0;

        }
        Vector3 input = new Vector3(0,0,0);
        
        if (_inputMethod == 0)
        {
            input = new Vector3(y,z,x);
        }
        else if (_inputMethod == 1)
        {
            input = new Vector3(x, z, y);
        }
        else
        {
            input = new Vector3(z, x, y);
            _inputMethod = 0;
        }

        
        transform.Rotate(input);
        
        
        if (_cnt > 60)
        {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("endpoint");
            text.text = gameObjects.Length.ToString();
            _cnt = 0;

            foreach (var go in GameObject.FindGameObjectsWithTag("Player"))
            {
                if (go.transform.position.y < -200)
                {
                    success.text = "실패";
                    success.gameObject.SetActive(true);
                    
                    if (ready)
                    {
                        StartCoroutine("Example");
                    }
                }
            }
            if (gameObjects.Length == 0)
            {
                success.gameObject.SetActive(true);
                text.gameObject.SetActive(false);
                StartCoroutine("Example");
            }
        }

        _cnt++;
    }
    
    
    IEnumerator Example() 
    {
        ready=false;

        print(Time.time);
        yield return new WaitForSeconds(5);

        SceneManager.LoadScene("Menu");
        ready=true;

    }
}
