using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateObject : MonoBehaviour
{

    [SerializeField]
    private float deactivateTimer = 3f;

    private void OnEnable()
    {
        Invoke("DeactivateGameObject", deactivateTimer);
    }

    private void OnDisable()
    {
        CancelInvoke("DeactivateGameObject");
    }

    void DeactivateGameObject()
    {
        if(gameObject.activeInHierarchy)
        {
            CancelInvoke("DeactivateGameObject");
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }


}

