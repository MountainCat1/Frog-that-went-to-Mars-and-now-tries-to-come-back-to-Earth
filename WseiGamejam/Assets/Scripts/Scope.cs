using UnityEngine;

public class Scope : MonoBehaviour
{
    [SerializeField]
    public float InputStrength = 1f;

    [SerializeField]
    private GameObject Bullet;

    void Update()
    {
        float H = Input.GetAxis("Horizontal");
        float V = Input.GetAxis("Vertical");

        transform.position += new Vector3(H, V, 0f) * Time.deltaTime * InputStrength;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Bullet, transform.position, Quaternion.identity);
        }
    }
}
