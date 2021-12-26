using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGrow : MonoBehaviour
{
    [SerializeField] Sprite decoTree;
    private int treeStage;
    private Vector3 startScale;
    private Vector3 endScale;
    [SerializeField] private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        treeStage = 0;
        startScale = new Vector3(1, 1, transform.localScale.z);

        // Y: start = 1 end = 5.85
        // X: start = 1 end = 4.48
        endScale = new Vector3(4.48f, 5.85f, transform.localScale.z);

    }

    // increases the height of the tree
    public void growTree()
    {
        print("growing tree");
        treeStage++;

        if (treeStage <= 10)
        {
            Vector3 scaleChange = new Vector3((endScale.x - startScale.x) / 10, (endScale.y - startScale.y) / 10, 0);
            print(scaleChange);
            transform.localScale += scaleChange;
            print(transform.localScale);

            if (treeStage == 10)
            {
                spriteRenderer.sprite = decoTree;
            }
        }

        
    }
}
