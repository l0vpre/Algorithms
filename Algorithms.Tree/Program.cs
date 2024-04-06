using Algorithms.Collections;
using Raylib_cs;
using System.Diagnostics.CodeAnalysis;
using System.Text;


VBinaryTree<int> tree  = [3,56];
Raylib.InitWindow(800, 400, "Binary tree");
bool isEnteringInput = false;
StringBuilder inputBuffer = new();
string message = "";
Color ColorError = Color.Red;
Color ColorSuccess = Color.Black;
Color messageColor = ColorSuccess;
Raylib.SetExitKey(KeyboardKey.F4);

while (!Raylib.WindowShouldClose())
{
    
    Raylib.BeginDrawing();
    
    if (isEnteringInput)
    {
        int c = Raylib.GetCharPressed();

        if (c is >= 0x20 and <= 0x7E)
            inputBuffer.Append(Convert.ToChar(c));

        if (Raylib.IsKeyPressed(KeyboardKey.Backspace)&&inputBuffer.Length !=0)
            inputBuffer.Length--;

        if(Raylib.IsKeyPressed(KeyboardKey.Escape))
        {
            isEnteringInput = false;
            inputBuffer.Clear();
        }
        
        if (Raylib.IsKeyPressed(KeyboardKey.Enter))
        {
            isEnteringInput = false;
            try
            {
                var num = int.Parse(inputBuffer.ToString());
                tree.Add(num);
                MessageSuccess($"Succesful added {num}");
            }
            catch
            {
                MessageError("Error parsing number");
            }
            inputBuffer.Clear();
        }
        Raylib.DrawText($"Add: {inputBuffer}", 100, 300, 35, Color.Black);
    }
    else
    {
        if (Raylib.IsKeyPressed(KeyboardKey.A))
        {
            isEnteringInput = true;
        }
    }
    
    Raylib.ClearBackground(Color.Beige);
    Raylib.DrawText(string.Join(" ", tree), 150, 100, 30, Color.Black); 
    Raylib.DrawText(message, 10, 250, 30, messageColor);
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