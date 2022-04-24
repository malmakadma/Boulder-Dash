# Boulder-Dash

abstract class Parents
{
    abstract public void Draw();
}
class Player : Parents
{
    public override void Draw()
    {
        Console.Write('I');
    }
}
class Sand : Parents
{
    public override void Draw()
    {
        Console.Write('.');
    }
}
class Empty : Parents
{
    public override void Draw()
    {
        Console.Write(' ');
    }
}
class Rock : Parents
{
    public override void Draw()
    {
        Console.Write('o');
    }
}
class Dimond : Parents
{
    public override void Draw()
    {
        Console.Write('D');
    }
}

class Program
{
    static void Main(string[] args)
    {
        Parents[,] field = new Parents[5, 16];

        //filling with sand
        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                field[i, j] = new Sand();
            }
        }
        //filling with Rock
        for (int i = 1; i < field.GetLength(0) - 1; i++)
        {
            field[i+1, 1] = new Rock();
            field[i, 6] = new Rock();
            field[i-1, 10] = new Rock();
        }

        //filling with Dimond
        for (int i = 0; i < field.GetLength(0); i+= 3)
        {
            for (int j = 0; j < field.GetLength(1); j+= 5)
            {
                field[i, j] = new Dimond();
            }
        }

        //filling with Empty
        field[0, 5] = new Empty();
        field[3, 14] = new Empty();
        field[3, 9] = new Empty();
        field[1, 14] = new Empty();
        field[3, 10] = new Empty();
        field[0, 15] = new Empty();
        field[4, 13] = new Empty();

        //Player
        field[3, 8] = new Player();

        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                field[i, j].Draw();
            }
            Console.WriteLine();
        }
    }
}
