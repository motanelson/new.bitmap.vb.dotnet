Imports System.Drawing
Imports System.Drawing.Imaging
'dotnet add package System.Drawing.Common
Module Program
    ' Tabela de cores VGA (R, G, B)
    Dim VGAColors() As Color = {
        Color.FromArgb(0, 0, 0),       ' 0 - Preto
        Color.FromArgb(170, 0, 0),     ' 1 - Vermelho
        Color.FromArgb(0, 170, 0),     ' 2 - Verde
        Color.FromArgb(170, 85, 0),    ' 3 - Castanho
        Color.FromArgb(0, 0, 170),     ' 4 - Azul
        Color.FromArgb(170, 0, 170),   ' 5 - Magenta
        Color.FromArgb(0, 170, 170),   ' 6 - Ciano
        Color.FromArgb(170, 170, 170), ' 7 - Cinzento claro
        Color.FromArgb(85, 85, 85),    ' 8 - Cinzento escuro
        Color.FromArgb(255, 85, 85),   ' 9 - Vermelho claro
        Color.FromArgb(85, 255, 85),   ' 10 - Verde claro
        Color.FromArgb(255, 255, 85),  ' 11 - Amarelo
        Color.FromArgb(85, 85, 255),   ' 12 - Azul claro
        Color.FromArgb(255, 85, 255),  ' 13 - Magenta claro
        Color.FromArgb(85, 255, 255),  ' 14 - Ciano claro
        Color.FromArgb(255, 255, 255)  ' 15 - Branco
    }

    Sub Main()
        Console.ForegroundColor = ConsoleColor.Black
        Console.BackgroundColor = ConsoleColor.DarkYellow
        Try
            Console.Write("Introduz a largura da imagem: ")
            Dim largura As Integer = Integer.Parse(Console.ReadLine())

            Console.Write("Introduz a altura da imagem: ")
            Dim altura As Integer = Integer.Parse(Console.ReadLine())

            Console.Write("Introduz o índice da cor VGA (0 a 15): ")
            Dim corIndex As Integer = Integer.Parse(Console.ReadLine())

            If corIndex < 0 OrElse corIndex > 15 OrElse largura <= 0 OrElse altura <= 0 Then
                Console.WriteLine("Erro: parâmetros inválidos.")
                Return
            End If

            Dim corFundo As Color = VGAColors(corIndex)

            Using bmp As New Bitmap(largura, altura, PixelFormat.Format32bppArgb)
                Using g As Graphics = Graphics.FromImage(bmp)
                    g.Clear(corFundo)
                End Using
                bmp.Save("new.bmp", ImageFormat.Bmp)
            End Using

            Console.WriteLine("Imagem 'new.bmp' criada com sucesso.")
        Catch ex As Exception
            Console.WriteLine("Erro: " & ex.Message)
        End Try
    End Sub
End Module
