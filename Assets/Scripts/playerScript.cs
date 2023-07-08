using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public GameObject rightPosition, leftPosition, deadPrefab, car;
    bool changePosition, startGame;
    public float speed;
    bool isDead = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (isDead)
        {
            return;
        }

        GetComponent<Rigidbody>().AddForce(Vector3.forward * speed * Time.deltaTime);

        if (changePosition && startGame)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(rightPosition.transform.position.x, transform.position.y, transform.position.z), 10f * Time.deltaTime);
        }

        if (!changePosition && startGame)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(leftPosition.transform.position.x, transform.position.y, transform.position.z), 10f * Time.deltaTime);
        }

        startGame = true;

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            changePosition = true;
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            changePosition = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (isDead)
        {
            return;
        }

        if (other.tag == "wall")
        {
            isDead = true;
            car.gameObject.SetActive(false);
            transform.gameObject.SetActive(false);

            for (int i = 0; i < 1; i++)
            {
                Instantiate(deadPrefab, transform.position, transform.rotation);
            }
        }

        if (other.tag == "finish")
        {
            Debug.Log("Finish");
        }
    }
}
