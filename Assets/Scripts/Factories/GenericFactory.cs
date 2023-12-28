using System.Collections.Generic;
using UnityEngine;


public class GenericFactory<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField]
    private T prefab;

    private List<GameObject> _currentStock;

    protected void Init()
	{
        _currentStock = new List<GameObject>();

	}

    public T GetObject(Vector3 position)
    {
        T result;
        if (_currentStock.Count > 0)
        {
            result = _currentStock[0].GetComponent<T>();
            _currentStock.RemoveAt(0);
        }
        else
        {
            result = Instantiate(prefab);
        }
        TurnOn(result, position);
        return result;
    }

    protected virtual void TurnOn(T obj, Vector3 position)
    {
        obj.transform.position = position;
        obj.gameObject.SetActive(true);
    }

    protected void TurnOff(T obj)
    {
        obj.gameObject.SetActive(false);
    }

    public void ReturnObject(T o)
    {
        TurnOff(o);
        _currentStock.Add(o.gameObject);
    }
}