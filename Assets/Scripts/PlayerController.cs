using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform playerTransform;
    [SerializeField]
    private float speed = 0f;

	[SerializeField]
    private float reloadBullet = 0f;

    [SerializeField]
    private float reloadSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cPos = Vector3.zero;
        Vector3 cRot = Vector3.zero;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
            cPos.x -= speed * Time.deltaTime;
            cRot.z = 20f;
        }
        
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            cPos.x += speed * Time.deltaTime;
            cRot.z = -20f;
        }
        
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            cPos.z -= speed * Time.deltaTime;
            cRot.x = 20f;
        }
        
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            cPos.z += speed * Time.deltaTime;
            cRot.x = -20f;
        }
        playerTransform.position += cPos;
        playerTransform.eulerAngles = cRot;

        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0))
		{
            reloadBullet += Time.deltaTime;
            if (reloadBullet >= reloadSpeed)
            {
                reloadBullet = 0f;
                ShootBullet();
            }
		}
		else
		{
            reloadBullet = 1f;
		}
    }


    public delegate void ShootAction(Vector3 position);
    public static event ShootAction OnShoot;
    private void ShootBullet()
	{
        if (OnShoot != null)
		{
            float randomizer = Random.Range(-.25f, .25f);
            Vector3 addPos = Vector3.forward;
            addPos.x = randomizer;
            OnShoot(this.transform.position + addPos);
		}
	}
}
