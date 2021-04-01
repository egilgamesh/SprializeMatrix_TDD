using System;
using System.Linq;
namespace SpiralizeMatrix
{
public class Matrix
{
int[,] Array;
int ArraySize;
int Rows,Columns;
int TopEdge = 0,leftEdge = 0,BottomEdge,RightEdge, Rotation = 0;
Direction direction;
public Matrix(int Size)
{
    ArraySize = Size;
    if (CheckSize()) {
        Array = SetInitialValues(ArraySize);
        Rows = Array.GetLength(0);
        Columns = Array.GetLength(1);
        BottomEdge = Rows - 1;
        RightEdge = Columns - 1;
        direction = Direction.Right;
    }
    else Console.WriteLine("Size of Matrix should be greater than or equal 5");
}
public bool CheckSize()
{
    if (ArraySize < 5) return false; else return true; 
}
public int[,] SetInitialValues(int Size)
{
    var InitialMatrix = new int[ArraySize, ArraySize];
    for (int Row = 0; Row < ArraySize; Row++)
        for (int Column = 0; Column < Size; Column++)
            InitialMatrix[Row, Column] = 0;
    return InitialMatrix;
}
public int[,] SprializeMatrix() { 
    while (TopEdge <= BottomEdge && leftEdge <= RightEdge){
        switch (direction){
            case Direction.Right:MoveRight();break;
            case Direction.Down:MoveDown();break;
            case Direction.Left:MoveLeft();break;
            case Direction.Up:MoveUp();break;
        }} return Array;
}
private void MoveUp() {
    for (int i = BottomEdge; (i >= TopEdge); i--)
    Array[i, leftEdge] = 1;
    leftEdge++;
    BottomEdge--;
    Rotation++;
    direction = Direction.Right;
}
private void MoveLeft(){
    for (int i = RightEdge; (i >= leftEdge); i--)
        Array[BottomEdge, i] = 1;
    BottomEdge--;
    RightEdge--;
    direction = Direction.Up;
}
private void MoveDown(){
    for (int i = TopEdge; (i <= BottomEdge); i++)
        Array[i, RightEdge] = 1;
    RightEdge--;
    TopEdge++;
    direction = Direction.Left;
}
private void MoveRight() {
    for (int i = leftEdge; (i <= RightEdge); i++)
        Array[TopEdge, i] = 1;
    TopEdge++;
    leftEdge += Rotation;
    direction = Direction.Down;
}
private enum Direction {
    Right,
    Down,
    Left,
    Up
}
}
}
