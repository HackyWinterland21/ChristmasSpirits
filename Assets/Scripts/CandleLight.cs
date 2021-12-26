using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CandleLight : MonoBehaviour
{
    private Light candleFlame;
    private SpriteRenderer spriteRenderer;
    private GameObject candleFlameFire;
    public static int numFlames;
    [SerializeField] GameObject background;
    [SerializeField] Material newMaterial;

    // Start is called before the first frame update
    void Start()
    {
        numFlames = 5;
        candleFlame = GetComponent<Light>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        candleFlameFire = transform.Find("Flame").gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerLighting playerLighting = collision.gameObject.GetComponent<PlayerLighting>();
            if (playerLighting.PlayerCandleFlame)
            {
                candleFlame.enabled = true;
                spriteRenderer.color = Color.white;
                candleFlameFire.SetActive(true);
                numFlames--;
                print(numFlames);
                if (numFlames == 0)
                {
                    StartCoroutine(LightUpScene());
                }
            }
        }
    }

    private IEnumerator LightUpScene()
    {

        yield return new WaitForSeconds(2); // Wait a couple seconds before the typing starts
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        yield return null;
    }
}
