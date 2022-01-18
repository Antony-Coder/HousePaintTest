using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Draw : MonoBehaviour
{
    [SerializeField] private Color[] wallDrawColors = new Color[4];

    private Texture2D tex;
    private Transform player;
    private Color drawColor;

    private UnityEvent drawedPointsCalculate = new UnityEvent();

    private List<Vector2> drawedPointsCoords = new List<Vector2>();
    private int drawedPointsCount;

    public int DrawedPointsCount { get => drawedPointsCount; set => drawedPointsCount = value; }
    public UnityEvent DrawedPointsCalculate { get => drawedPointsCalculate;}

    public void Enable(int numberWall)
    {
        tex = Manager.Get.Wall.GetComponent<SpriteRenderer>().sprite.texture;
        player = Manager.Get.Player;
        drawColor = wallDrawColors[numberWall];
        drawedPointsCount = 0;
        drawedPointsCalculate.Invoke();
        drawedPointsCoords.Clear();
        Manager.Get.UpdateEvent.AddListener(UpdateFunc);
    }


    public void Disable()
    {
        Manager.Get.UpdateEvent.RemoveListener(UpdateFunc);

    }

    private void UpdateFunc()
    {

        int x = (int)(player.localPosition.x - Manager.Get.MoveSystem.Direction.x * 0.25f);
        int y = (int)(player.localPosition.y - Manager.Get.MoveSystem.Direction.y * 0.25f);

        tex.SetPixel(x, y, drawColor);
        tex.Apply();

        Vector2 drawedPixel = new Vector2(x, y);

        if (!drawedPointsCoords.Contains(drawedPixel))
        {
            drawedPointsCount++;
            drawedPointsCoords.Add(drawedPixel);        
        }


        if (drawedPointsCount == tex.height * tex.width)
        {
            Disable();
            Manager.Get.GameController.GameStepHendler();
        }
    }




}
