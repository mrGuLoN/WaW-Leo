using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolIdentificate : MonoBehaviour
{
    public PollObjects.ObjectInfo.ObjectType Type => type;
    [SerializeField] private PollObjects.ObjectInfo.ObjectType type;

    public void Destroyer(GameObject gameObject)
    {
        StartCoroutine(Destroy(gameObject));
    }

    IEnumerator Destroy(GameObject gameObject)
    {
        yield return new WaitForSeconds(1);
        Debug.Log("Destroy");
        Destroy(gameObject);
    }
}
