using Algorithms.Collections;
using Algorithms.Interfaces;
using Raylib_cs;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics.CodeAnalysis;
using System.Text;


Color ColorError = Raylib.GetColor(0xf80616FF);
Color ColorSuccess = Raylib.GetColor(0xbfd6c7FF);
Color ColorTextBox = Raylib.GetColor(0x232224DD);
Color ColorText = Raylib.GetColor(0xd9d6dbFF);
Color ColorTree = Raylib.GetColor(0x777579FF);
Color ColorBackground1 = Raylib.GetColor(0x313032FF);
Color ColorBackground2 = Raylib.GetColor(0x292829FF);

VBinaryTree<int> tree = new ();

bool isEnteringInput = false;
StringBuilder inputBuffer = new();
string message = "Add your fisrt item!!";
Color messageColor = ColorSuccess;
string text = string.Empty;
Action<int> textBoxAction = TextBoxAdd;

Raylib.SetConfigFlags(ConfigFlags.ResizableWindow);
Raylib.InitWindow(800, 400, "Binary tree");
Raylib.SetExitKey(KeyboardKey.F4);

while (!Raylib.WindowShouldClose())
{
    int width = Raylib.GetRenderWidth();
    int height = Raylib.GetRenderHeight();
    Raylib.BeginDrawing();
    Raylib.DrawRectangleGradientV(0, 0, Raylib.GetScreenWidth(),Raylib.GetScreenHeight(),ColorBackground1, ColorBackground2);

    if (tree.Root is not null)
    {
        DrawTree(tree.Root, 0, width);
    }

    if (isEnteringInput)
    {
        TextBox();
    }
    else
    {
        if (Raylib.IsKeyPressed(KeyboardKey.A))
        {
            text = "Add";
            textBoxAction = TextBoxAdd;
            isEnteringInput = true;
        }

        if(Raylib.IsKeyPressed(KeyboardKey.R))
        {
            text = "Remove";
            textBoxAction = TextBoxRemove;
            isEnteringInput = true;
        }
        if(Raylib.IsKeyPressed(KeyboardKey.B))
        {
            MessageError("No");
        }
    }
    
    Raylib.DrawText(message, 10, height - 35, 25, messageColor);
    Raylib.EndDrawing();
}

Raylib.CloseWindow();

void MessageError(string mes)
{
    message = mes;
    messageColor = ColorError;
}
void MessageSuccess(string mes)
{
    message = mes;
    messageColor = ColorSuccess;
}

void TextBox()
{
    int c = Raylib.GetCharPressed();

    if (c is >= 0x20 and <= 0x7E && inputBuffer.Length < 9)
        inputBuffer.Append(Convert.ToChar(c));

    if (Raylib.IsKeyPressed(KeyboardKey.Backspace) && inputBuffer.Length != 0)
        inputBuffer.Length--;

    if (Raylib.IsKeyPressed(KeyboardKey.Escape))
    {
        isEnteringInput = false;
        message = " ";
        inputBuffer.Clear();
    }

    if (Raylib.IsKeyPressed(KeyboardKey.Enter))
    {
        try
        {
            var num = int.Parse(inputBuffer.ToString());
            textBoxAction(num);
        }
        catch
        {
            MessageError("Error parsing number");
        }
        isEnteringInput = false;
        inputBuffer.Clear();
    }
    int RecWidth = (text.Length + 11)*21;
    int RecHeight = 50;
    Rectangle rec = new(
        (Raylib.GetScreenWidth() - RecWidth)/2,
        (Raylib.GetScreenHeight() - RecHeight)/2,
        RecWidth, RecHeight);
    Raylib.DrawRectangleRec(rec, ColorTextBox);
    Raylib.DrawText($"{text}: {inputBuffer}", (int)rec.X+10,(int)rec.Y+10, 35, ColorText);
}


void TextBoxAdd(int num)
{
    tree.Add(num);
    MessageSuccess($"Successfully added {num}");
}

void TextBoxRemove(int num)
{
    if (tree.Remove(num))
    {
        MessageSuccess($"Successfully removed {num}");
    }
    else
    {
        MessageSuccess($"{num} is not in the tree");
    }
}

void DrawTree(IBNode<int> root, int left, int right,int depth = 1)
{
    int depthMultiplyer = Raylib.GetScreenHeight() / 10;
    string text = root.Data.ToString();
    int fontSize = 30;

    int middle = (right + left) / 2;
    if (root.Left is not null)
    {
        Raylib.DrawLine(middle, depth * depthMultiplyer, (left + middle) / 2,(depth+1)*depthMultiplyer,ColorTree);
        DrawTree(root.Left, left, middle, depth + 1);
    }
    if (root.Right is not null)
    {
        Raylib.DrawLine(middle, depth * depthMultiplyer, (right + middle) / 2,(depth+1)*depthMultiplyer,ColorTree);
        DrawTree(root.Right, middle, right, depth + 1);
    }

    Raylib.DrawCircle(middle, depth * depthMultiplyer, 45, ColorTree);
    Raylib.DrawText(text,
        middle-Raylib.MeasureText(text,fontSize)/2,
        depth*depthMultiplyer-fontSize/2,
        fontSize,
        ColorText);
}