using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MilkShake;

[RequireComponent(typeof(Rigidbody2D))]
public class DaisyController : MonoBehaviour
{
    [SerializeField] private Vector2 speed;
    [SerializeField] private float gravity;
    [SerializeField] private GameObject hitParticles;
    private Rigidbody2D rb;

    float xInput;
    float yInput;

    [Header("Graphics")]
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform mesh;
    [SerializeField] private DaisyGraphics graphics;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private Transform cam;

    [SerializeField] private ShakePreset shakePreset;

    private float score;

    bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(isDead) return;
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        mesh.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        score += Time.deltaTime;

        uiManager.UpdateScore((int)score);

        if(Mathf.Abs(cam.position.y - transform.position.y) > 7)
        {
            isDead = true;
            uiManager.EndGame();
        }

        if(graphics.numPetals == 0 && !isDead)
        {
            isDead = true;
            uiManager.EndGame();
        }
    }

    void FixedUpdate()
    {
        if(isDead) return;
        rb.AddForce(Vector2.right * speed.x * xInput * Time.fixedDeltaTime, ForceMode2D.Force);
        rb.AddForce(Vector2.up * speed.y * yInput * Time.fixedDeltaTime, ForceMode2D.Force);

        rb.position -= GetGravPosDelta();
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.transform.CompareTag("WIND"))
        {
            rb.AddForce(-col.transform.right * 30, ForceMode2D.Force);
        }
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.transform.CompareTag("DEATH"))
        {
            Shaker.ShakeAll(shakePreset);
            graphics.RemovePetal();
            Instantiate(hitParticles, col.contacts[0].point, Quaternion.FromToRotation(hitParticles.transform.up, col.contacts[0].normal) * hitParticles.transform.rotation);
            GetComponent<AudioSource>().Play();
        }
    }

    void Death()
    {
        
    }

    public Vector2 GetGravPosDelta()
    {   
        if(graphics.numPetals == 0) return Vector2.zero;
        return Vector2.up * gravity * Time.fixedDeltaTime * GetPetalMultiplier();
    }

    public float GetPetalMultiplier()
    {
        if(graphics.numPetals == 0) return 0;
        return  1 + 1 / (graphics.numPetals * 1f);
    }
        

}
