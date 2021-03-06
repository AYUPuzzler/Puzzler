using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidePuzzle : MonoBehaviour
{
    public Texture2D image;
    public int blocksPerLine;
    public int shuffleLength;
    public float defaultMoveDuration = .2f;
    public float shuffleMoveDuration = .1f;
    bool ShuffleOn;

    Block emptyBlock;
    Block[,] blocks;
    Queue<Block> inputs;
    bool blockIsMoving;
    int shuffleMovesRemaining;
    Vector2Int preShuffleOffset;

    enum PuzzleState { Solved, Shuffling, InPlay};
    PuzzleState state;
    // Start is called before the first frame update


    void Start()
    {
        //Texture2D image = ManagerData.instanceData.texture2D;
        //TextureImporter importer = AssetImporter.GetAtPath(path) as TextureImporter;
        //Destroy(GameObject.Find("StartPanel")); // ?ӽ? ??!!!!!!!!@@@@@@@@@@@@!!!!!!!!!!@@@@@@@@@@
        CreateSlidePuzzle();
        shuffleLength = ManagerData.instanceData.slideLevel * 20;
        StartShuffle();
    }

    //void Update()
    //{
    //    if (state == PuzzleState.Solved && Input.GetKeyDown(KeyCode.Space))
    //    {
    //        StartShuffle();
    //        Destroy(GameObject.Find("StartPanel"));
    //    }
    //}
    public void OnClick() {
        Destroy(GameObject.Find("StartPanel"));
    }

    void CreateSlidePuzzle() 
    {
        blocksPerLine = ManagerData.instanceData.slideLevel;
        blocks = new Block[blocksPerLine, blocksPerLine];
        Texture2D[,] imageSlices = ImageSlicer.GetSlices(image, blocksPerLine);

        for (int y = 0; y < blocksPerLine; y++)
        {
            for (int x = 0; x < blocksPerLine; x++) {
                GameObject blockObject = GameObject.CreatePrimitive(PrimitiveType.Quad);
                blockObject.transform.position = -Vector2.one * (blocksPerLine - 1) * .5f + new Vector2(x, y);
                blockObject.transform.parent = transform;

                Block block = blockObject.AddComponent<Block>();
                block.OnBlockPressed += PlayerMoveBlockInput;
                block.OnFinshedMoving += OnBlockFinshedMoving;
                block.Init(new Vector2Int(x, y), imageSlices[x, y]);
                blocks[x, y] = block;

                if (y == 0 && x == blocksPerLine - 1)
                {
                   emptyBlock = block;
                }
            }
        }
        Camera.main.orthographicSize = blocksPerLine * .55f;
        inputs = new Queue<Block>();
    }

    void PlayerMoveBlockInput(Block blockToMove)
    {
        if (state == PuzzleState.InPlay)
        {
            inputs.Enqueue(blockToMove);
            MakeNextPlayerMove();
        }
    }

    void MakeNextPlayerMove()
    {
        while (inputs.Count > 0 && !blockIsMoving)
        {
            MoveBlock(inputs.Dequeue(), defaultMoveDuration);
        }
    }

    void MoveBlock(Block blockToMove, float duration)
    {
        if ((blockToMove.coord - emptyBlock.coord).sqrMagnitude == 1)
        {
            blocks[blockToMove.coord.x, blockToMove.coord.y] = emptyBlock;
            blocks[emptyBlock.coord.x, emptyBlock.coord.y] = blockToMove;

            Vector2Int targetCoord = emptyBlock.coord;
            emptyBlock.coord = blockToMove.coord;
            blockToMove.coord = targetCoord;

            Vector2 targetPosition = emptyBlock.transform.position;
            emptyBlock.transform.position = blockToMove.transform.position;
            if (ShuffleOn)
            {
                Debug.Log("duration = 0");
                blockToMove.MoveToPosition(targetPosition, 0);
            }
            else
            {
                Debug.Log("duration = " + duration);
                blockToMove.MoveToPosition(targetPosition, duration);
            }
            blockIsMoving = true;
            GameObject.Find("Sound").GetComponent<AudioSource>().Play();
        }
    }

    void OnBlockFinshedMoving()
    {
        blockIsMoving = false;
        CheckIfSolved();

        if (state == PuzzleState.InPlay)
        {
            MakeNextPlayerMove();
        }
        else if (state == PuzzleState.Shuffling)
        {
            if (shuffleMovesRemaining > 0)
            {
                MakeNextShuffleMove();
            }
            else
            {
                state = PuzzleState.InPlay;
            }
        }
    }

    void StartShuffle()
    {
        ShuffleOn = true;
        state = PuzzleState.Shuffling;
        shuffleMovesRemaining = shuffleLength;
        emptyBlock.gameObject.SetActive(false);
        MakeNextShuffleMove();
        //ShuffleOn = false; // ?̰? ?????? ?־????Ұ?
    }


    void MakeNextShuffleMove()
    {
        Vector2Int[] offsets = { new Vector2Int(1, 0), new Vector2Int(-1, 0), new Vector2Int(0, 1), new Vector2Int(0, -1) };
        int randoIndex = Random.Range(0, offsets.Length);

        for (int i = 0; i < offsets.Length; i++)
        {
            Vector2Int offset = offsets[(randoIndex + i) % offsets.Length];
            if (offset != preShuffleOffset * -1)
            {
                Vector2Int moveBlockCoord = emptyBlock.coord + offset;

                if (moveBlockCoord.x >= 0 && moveBlockCoord.x < blocksPerLine && moveBlockCoord.y >= 0 && moveBlockCoord.y < blocksPerLine)
                {
                    MoveBlock(blocks[moveBlockCoord.x, moveBlockCoord.y], shuffleMoveDuration);
                    shuffleMovesRemaining--;
                    preShuffleOffset = offset;
                    break;
                }
            }
        }
        if(shuffleMovesRemaining == 0)
            ShuffleOn = false; // 0?? ?Ǵ? ???? ?????̵? ?ִϸ??̼? ????
    }

    void CheckIfSolved()
    {
        foreach(Block block in blocks)
        {
            if (!block.IsAtStartingcoord())
            {
                return;
            }
        }
        state = PuzzleState.Solved;
        emptyBlock.gameObject.SetActive(true);
        GameObject.Find("SCCanvas").transform.Find("ClearPanel").gameObject.SetActive(true);

        if(ManagerData.instanceData.B_Anyang == 1)
            GameObject.Find("SCCanvas").transform.Find("ClearPanel").transform.Find("sin").gameObject.SetActive(true);
        else if(ManagerData.instanceData.B_Anyang == 2)
            GameObject.Find("SCCanvas").transform.Find("ClearPanel").transform.Find("suri").gameObject.SetActive(true);
        else if (ManagerData.instanceData.B_Anyang == 3)
            GameObject.Find("SCCanvas").transform.Find("ClearPanel").transform.Find("bong").gameObject.SetActive(true);
        else if (ManagerData.instanceData.B_Anyang == 4)
            GameObject.Find("SCCanvas").transform.Find("ClearPanel").transform.Find("vision").gameObject.SetActive(true);
        else if (ManagerData.instanceData.B_Anyang == 5)
            GameObject.Find("SCCanvas").transform.Find("ClearPanel").transform.Find("ari").gameObject.SetActive(true);
        else if (ManagerData.instanceData.B_Anyang == 6)
            GameObject.Find("SCCanvas").transform.Find("ClearPanel").transform.Find("lib").gameObject.SetActive(true);
    }

}
