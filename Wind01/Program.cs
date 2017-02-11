using System;

using System.Windows.Forms;

using System.IO;
using System.Collections.Generic;

static class ListManip
{

    private static Random rng = new Random();

    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
    public static void RollLeft<T>(this IList<T> list)
    {
        int n = list.Count;
        T value = list[n - 1];
        for(int i=n-1;i>0;i--)
        {
            list[i] = list[i - 1];
        }
        
        list[0] = value;
    }
    public static List<T> Choice<T>(this IList<T> list, int ile)
    {
        List<T> lista = new List<T>();
        int n = list.Count;
        int c;
        for (int i = 0; i < ile; i++)
        { 
            c = rng.Next(n);
            lista.Add(list[c]);
            list.RemoveAt(c);
            n--;


        }
        return lista;
    }

}

class Sudoku
{
    public int[,] sudokuTab;
    public int[][,] sudokuTabTab;
    
    public int cntPos = 0;
    public int max = 0;

    public int trafny = 0;
    public int nietrafny = 0;

   // public List<int> row = new List<int>();

    public Sudoku()
    {
        sudokuTab = new int[9, 9];
        sudokuTabTab = new int[6][,];
        sudokuTabTab[0] = new int[9, 9];
        sudokuTab[3, 4] = 2;
        sudokuTab[5, 4] = 2;
        sudokuTab[3, 2] = 3;
        sudokuTab[5, 5] = 3;
        sudokuTab[3, 5] = 3;
        sudokuTab[0, 0] = 2;
        sudokuTab[1, 1] = 3;
        sudokuTab[0, 2] = 2;
        sudokuTab[1, 2] = 3;
    }
    public Sudoku(int[,] matrix)
    {
        sudokuTab = matrix;
    }
    private static int[] GetRow()
    {
        int[] tab = new int[9];
        string dane;
        string[] stringTab;
        Console.WriteLine("Wproadz dane do rzędu");
        dane = Console.ReadLine();
        stringTab = dane.Split(' ');
        for (int i = 0; i < 9; i++)
            tab[i] = Int32.Parse(stringTab[i]);
        return tab;
    }
    public static Sudoku GetSudokuFromFile(string file)
    {
        Sudoku sudoku = new Sudoku();
        StreamReader sr = new StreamReader(file);
        int[] tab = new int[9];
        string dane;
        string[] stringTab;
        for (int i = 0; i < 9; i++)
        {
            dane = sr.ReadLine();
            stringTab = dane.Split(' ');
            for (int j = 0; j < 9; j++)
            {
                tab[j] = Int32.Parse(stringTab[j]);
                sudoku.sudokuTab[i, j] = tab[j];
            }
        }
        sr.Close();
        return sudoku;

    }

    public static Sudoku GetSudokuFromFileParser(string file)
    {
        Sudoku sudoku = new Sudoku();
        StreamReader sr = new StreamReader(file);
        int[] tab = new int[9];
        string dane;
        char[] charTab = new char[9];
        for (int i = 0; i < 9; i++)
        {
            dane = sr.ReadLine();


            for (int j = 0; j < 9; j++)
            {
                charTab[j] = dane[j];
                sudoku.sudokuTab[i, j] = (int)Char.GetNumericValue(charTab[j]);
            }
        }
        sr.Close();
        return sudoku;

    }
    public static Sudoku GetSudoku()
    {
        Sudoku sudoku = new Sudoku();
        int[] tab = new int[9];
        for (int i = 0; i < 9; i++)
        {
            tab = GetRow();
            for (int j = 0; j < 9; j++)
                sudoku.sudokuTab[i, j] = tab[j];
        }
        return sudoku;
    }



    public int[] GetKwadrat(int ktory)
    {
        int[] kwadrat = new int[9];
        int cnt = 0;
        switch (ktory)
        {

            case 0:
                {
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            kwadrat[cnt] = sudokuTab[i, j];
                            cnt++;
                        }
                    }
                    break;
                }

            case 1:
                {
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 3; j < 6; j++)
                        {
                            kwadrat[cnt] = sudokuTab[i, j];
                            cnt++;
                        }
                    }
                    break;
                }
            case 2:
                {
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 6; j < 9; j++)
                        {
                            kwadrat[cnt] = sudokuTab[i, j];
                            cnt++;
                        }
                    }
                    break;
                }

            case 3:
                {
                    for (int i = 3; i < 6; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            kwadrat[cnt] = sudokuTab[i, j];
                            cnt++;
                        }
                    }
                    break;
                }
            case 4:
                {
                    for (int i = 3; i < 6; i++)
                    {
                        for (int j = 3; j < 6; j++)
                        {
                            kwadrat[cnt] = sudokuTab[i, j];
                            cnt++;
                        }
                    }
                    break;
                }
            case 5:
                {
                    for (int i = 3; i < 6; i++)
                    {
                        for (int j = 6; j < 9; j++)
                        {
                            kwadrat[cnt] = sudokuTab[i, j];
                            cnt++;
                        }
                    }
                    break;
                }
            case 6:
                {
                    for (int i = 6; i < 9; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            kwadrat[cnt] = sudokuTab[i, j];
                            cnt++;
                        }
                    }
                    break;
                }
            case 7:
                {
                    for (int i = 6; i < 9; i++)
                    {
                        for (int j = 3; j < 6; j++)
                        {
                            kwadrat[cnt] = sudokuTab[i, j];
                            cnt++;
                        }
                    }
                    break;
                }
            case 8:
                {
                    for (int i = 6; i < 9; i++)
                    {
                        for (int j = 6; j < 9; j++)
                        {
                            kwadrat[cnt] = sudokuTab[i, j];
                            cnt++;
                        }
                    }
                    break;
                }
        }
        return kwadrat;
    }

    public static void WyswietlKwadrat(int[] wadrat)

    {
        for (int i = 0; i < 9; i++)
        {
            Console.Write(wadrat[i] + " ");
            if (i == 2 || i == 5 || i == 8)
            {
                Console.WriteLine();
            }
        }
    }
    public void WyswietlSudoku()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                Console.Write(sudokuTab[i, j]);
                if (j == 2 || j == 5)
                {
                    Console.Write('\t');
                }
            }
            Console.WriteLine();
            if (i == 2 || i == 5)
                Console.WriteLine();
        }
    }

    public int CheckIsInKwadrat(int ktory, int liczba)
    {
        int[] kw = this.GetKwadrat(ktory);
        for (int i = 0; i < 9; i++)
        {
            if (kw[i] == liczba)
                return i;
        }
        return -1;
    }
    public int[] PositionToMatrix(int kw, int pos)
    {
        int[] zwrotna = new int[3];
        int row, column;
        if (kw < 3)
            row = kw / 3 + pos / 3;
        else if (kw >= 3 && kw < 6)
            row = kw / 3 + pos / 3 + 2;
        else
            row = kw / 3 + pos / 3 + 4;
        if (kw % 3 == 0)
            column = kw % 3 + pos % 3;
        else if (kw % 3 == 1)
            column = kw % 3 + pos % 3 + 2;
        else
            column = kw % 3 + pos % 3 + 4;
        //Console.WriteLine("row col" + row + column);
        zwrotna[0] = row;
        zwrotna[1] = column;
        zwrotna[2] = sudokuTab[row, column];
        return zwrotna;
    }

    public bool CheckPosition(int kw, int pos, int liczba)
    {
        int[] tab = new int[3];
        tab = this.PositionToMatrix(kw, pos);
        if (tab[2] != 0)
            return false;

        for (int j = 0; j < 9; j++)
        {
            if (liczba == sudokuTab[tab[0], j])
                return false;
        }
        for (int i = 0; i < 9; i++)
        {
            if (liczba == sudokuTab[i, tab[1]])
                return false;
        }
        return true;
    }
    public bool CheckRow(int row, int liczba)
    {
        for (int i = 0; i < 9; i++)
        {
            if (liczba == sudokuTab[row, i])
                return true;
        }
        return false;
    }
    public bool CheckColumn(int column, int liczba)
    {
        for (int i = 0; i < 9; i++)
        {
            if (liczba == sudokuTab[i, column])
                return true;
        }
        return false;
    }



    public int CheckNumberInKwadrat(int kw, int liczba)
    {
        bool found = false;
        int pos = -1;
        if (this.CheckIsInKwadrat(kw, liczba) != -1)
            return -1;
        for (int i = 0; i < 9; i++)
        {
            if (this.PositionToMatrix(kw, i)[2] != 0)
                continue;

            if (this.CheckPosition(kw, i, liczba) && !found)
            {
                found = true;
                pos = i;
            }
            else if (this.CheckPosition(kw, i, liczba) && found)
                return -1;
        }
        if (!found)
            return -1;
        else
            return pos;

    }




    public void CheckKwadrat(int kw)
    {
        int[] positions = new int[10];
        int pos;
        for (int i = 1; i < 10; i++)
        {
            pos = this.CheckNumberInKwadrat(kw, i);
            if (pos >= 0)
            {
                if (positions[pos] == 0)
                {
                    positions[pos] = i;
                }
                else
                {
                    positions[pos] = 0;
                    continue;
                }

            }
        }
        for (int i = 0; i < 9; i++)
        {
            if (positions[i] != 0)
            {
                // Console.WriteLine("Wpisuję liczbę " + positions[i]+" na pozycji "+i);
                sudokuTab[this.PositionToMatrix(kw, i)[0], this.PositionToMatrix(kw, i)[1]] = positions[i];
            }
        }
    }
    public void Check()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 9; j++)
                this.CheckKwadrat(j);
        }
    }
    public bool IsSolution()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (sudokuTab[i, j] == 0)
                    return false;
            }

        }
        return true;
    }

    public int[,] Copy()
    {
        int[,] sud = new int[9, 9];

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                sud[i, j] = sudokuTab[i, j];

            }

        }
        return sud;
    }
    public int[,] CopyReverse(int[,] rev)
    {
        int[,] sud = new int[9, 9];

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                sud[i, j] = rev[i, j];

            }

        }
        return sud;
    }
    public int FindZeroesInKwadrat(int kw)
    {
        int counter = 0;
        int[] tab = new int[9];
        tab = this.GetKwadrat(kw);
        for (int i = 0; i < 9; i++)
        {
            if (tab[i] == 0)
                counter++;
        }

        return counter;

    }
    public int[] FindWhereZeroesInKwadrat(int kw)
    {
        int counter = 0;
        int[] tab = new int[9];
        tab = this.GetKwadrat(kw);
        for (int i = 0; i < 9; i++)
        {
            if (tab[i] == 0)
            {
                tab[counter] = i;
                counter++;
            }

        }
        Console.WriteLine("Z wnętrza tab[0] i[1] " + tab[0] + tab[1]);
        return tab;
    }

    public int[] FindLackingNumbers(int kw)
    {
        int[] tab = new int[9];
        int[] zwrotna = new int[9];
        bool found = false;
        int counter = 0;
        tab = this.GetKwadrat(kw);
        for (int i = 1; i < 10; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (tab[j] == i)
                    found = true;

            }
            if (!found)
            {
                zwrotna[counter] = i;
                counter++;
            }
            found = false;
        }

        return zwrotna;

    }




    public int zlicz()
    {
        int licznik = 0;
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (sudokuTab[i, j] != 0)
                    licznik++;
            }
        }
        return licznik;
    }

    public void InputInMatrix(int kw, int pos, int liczba)
    {
        sudokuTab[this.PositionToMatrix(kw, pos)[0], this.PositionToMatrix(kw, pos)[1]] = liczba;
    }

    public bool InputInMatrixBool(int kw, int pos, int liczba)
    {
        if (!this.CheckPosition(kw, pos, liczba) || this.CheckIsInKwadrat(kw, liczba) != -1)
        {
            //Console.WriteLine("NIE można wstawić...");
            return false;
        }
        else
        {
            Console.WriteLine(" można wstawić...");
            sudokuTab[this.PositionToMatrix(kw, pos)[0], this.PositionToMatrix(kw, pos)[1]] = liczba;
            return true;
        }
    }

    private static void Swap(ref int a, ref int b)
    {
        if (a == b) return;

        a ^= b;
        b ^= a;
        a ^= b;
    }

    public void GetPer(int[] list, int[] tab)
    {
        int cnt = 0;
        int x = list.Length - 1;
        Console.WriteLine("list Leng" + list.Length);
        GetPer(list, 0, x, ref cnt, tab);
    }

    private static void GetPer(int[] list, int k, int m, ref int cnt, int[] tab)
    {
        if (k == m)
        {
            for (int i = 0; i < list.Length; i++)
            {
                tab[cnt] = list[i];
                cnt++;
                //Console.WriteLine(cnt);
            }
            //Console.WriteLine();


        }
        else
            for (int i = k; i <= m; i++)
            {
                Swap(ref list[k], ref list[i]);
                GetPer(list, k + 1, m, ref cnt, tab);
                Swap(ref list[k], ref list[i]);
            }
    }

    public bool DeepSearch(bool rec = false)
    {


        int cnt = 0;
        for (int i = 0; i < 9; i++)
        {
            if (this.FindZeroesInKwadrat(i) >= 3 && this.FindZeroesInKwadrat(i) <= 7)
            {
                Console.WriteLine("Znaleziono" + ++cnt);
                if (this.CompleteKwadrat(this.FindZeroesInKwadrat(i), i, rec))
                    return true;
            }
        }

        return false;
    }

    public bool CompleteKwadrat(int ile, int kw, bool rec = false)

    {

        Console.WriteLine("wewnątrz" + this.Factorial(ile));
        int[,] temp = new int[9, 9];
        int[] positions = new int[ile];
        int[] numbers = new int[ile];
        int[] numb = new int[ile];
        positions = this.FindWhereZeroesInKwadrat(kw);
        Console.WriteLine("wewnątrz" + this.Factorial(ile));
        numbers = this.FindLackingNumbers(kw);

        for (int i = 0; i < ile; i++)
        {
            numb[i] = numbers[i];

        }






        Console.WriteLine("numbers" + numbers.Length);
        int[] permTable = new int[this.Factorial(ile) * ile];
        Console.WriteLine("wewnątrz" + this.Factorial(ile));
        this.GetPer(numb, permTable);
        /*
        for(int i=0;i<4;i++)
        {
            Console.WriteLine("Positions "+positions[i]);
            Console.WriteLine("numbers "+numb[i]);
            Console.WriteLine("Permtab "+ permTable.Length);
            Console.WriteLine("Permtab "+permTable[i]);
        }
        */

        for (long i = 0; i < (this.Factorial(ile) * ile); i += ile)
        {



            bool flag = true;
            temp = this.Copy();
            int cnt = 0;
            for (long k = i; k < i + ile; k++)
            {

                Console.WriteLine("Debug" + kw + positions[cnt] + permTable[k]);
                if (!this.InputInMatrixBool(kw, positions[cnt], permTable[k]))
                {
                    flag = false;
                    nietrafny++;
                }
                else
                    trafny++;

                cnt++;

            }
            Console.WriteLine();
            //this.WyswietlSudoku();
            if (flag)
            {
                Console.WriteLine("Sprawdzam..........................................");
                this.Check();
                if (this.IsSolution())
                {
                    Console.WriteLine();
                    //this.WyswietlSudoku();
                    Console.WriteLine("JEst");
                    Console.WriteLine("trafne:  " + trafny);
                    Console.WriteLine("nietrafne:  " + nietrafny);
                    return true;
                }
                else
                {
                    if (rec)
                    {
                        if (this.DeepSearch(false))
                            return true;
                    }

                }


            }
            sudokuTab = this.CopyReverse(temp);
            //this.WyswietlSudoku();

        }
        this.WyswietlSudoku();
        Console.WriteLine("trafne:  " + trafny);
        Console.WriteLine("nietrafne:  " + nietrafny);
        Console.WriteLine("nie ma");
        return false;

    }

    public int Factorial(int numb)
    {

        if (numb == 1)
            return 1;
        return numb * Factorial(numb - 1);



    }

    public void inputRow(IList<int> list, int row)
    {
        for(int i = 0; i < 9; i++)
        {
            this.sudokuTab[row, i] = list[i];
        }
    }

    public static Sudoku Create()
    {
        Sudoku sudoku = new Sudoku();
        int[] helpTab = new int[] { 0, 3, 6, 1, 4, 7, 2, 5, 8 };
        List<int> row = new List<int>();
        for(int i =1;i<10;i++)
        {
            row.Add(i);
        }
        ListManip.Shuffle<int>(row);
        /*
        for (int i =0 ; i < 9; i++)
        {
            Console.Write(row[i]);
        }
        Console.WriteLine();
        for(int i=0;i<15;i++)
        {
            ListManip.RollLeft<int>(row);
            for (int j = 0; j < 9; j++)
            {
                Console.Write(row[j]);
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        */
        for(int i=0;i<9;i++)
        {
            sudoku.inputRow(row, helpTab[i]);
            ListManip.RollLeft<int>(row);
        }
        return sudoku;

    }

    public void Recomb()
    {
        Random rand = new Random();
        
        int temp;
        for (int z = 0; z < 9; z += 3)
        {
            for (int g = 0; g < 3; g++)
            {
                int k = rand.Next(2);
                Console.WriteLine(k);
                if (k == 0)
                {
                    for (int i = g; i < 9; i += 3)
                    {



                        Console.WriteLine("ZAMIANA" + i);
                        temp = this.sudokuTab[z, i];
                        this.sudokuTab[z, i] = this.sudokuTab[z+2, i];
                        this.sudokuTab[z+2, i] = temp;


                    }
                }
            }
        }


        for (int z = 0; z < 9; z += 3)
        {
            for (int g = 0; g < 3; g++)
            {
                int k = rand.Next(2);
                Console.WriteLine(k);
                if (k == 0)
                {
                    for (int i = g; i < 9; i += 3)
                    {



                        Console.WriteLine("ZAMIANA" + i);
                        temp = this.sudokuTab[z, i];
                        this.sudokuTab[z, i] = this.sudokuTab[z + 1, i];
                        this.sudokuTab[z + 1, i] = temp;


                    }
                }
            }
        }
        for (int z = 0; z < 9; z += 3)
        {
            for (int g = 0; g < 3; g++)
            {
                int k = rand.Next(2);
                Console.WriteLine(k);
                if (k == 0)
                {
                    for (int i = g; i < 9; i += 3)
                    {



                        Console.WriteLine("ZAMIANA" + i);
                        temp = this.sudokuTab[z+1, i];
                        this.sudokuTab[z+1, i] = this.sudokuTab[z + 2, i];
                        this.sudokuTab[z + 2, i] = temp;


                    }
                }
            }
        }

    }

    public void Cancel(int kw, int ile)
    {
        List<int> cancelTable = new List<int>();
        List<int> posTable = new List<int>();
        for(int i=0;i<9;i++)
        {
            posTable.Add(i);
        }
        cancelTable = ListManip.Choice<int>(posTable, ile);
        for(int i =0;i<ile;i++)
        {
            this.InputInMatrix(kw, cancelTable[i], 0);
        }

    }
    public void CancelAll()
    {
        //int[] helpTable = new int[10] { 3,3,4, 4,5,5, 5,6, 6,7 };
        List<int> list = this.CreatePropTable(4);
        Random rnd = new Random();
        //int choice = rnd.Next(4);
        for(int i =0;i<9;i++)
        {
            Console.WriteLine("wewnątrz CancelAll");
             this.Cancel(i, list[rnd.Next(list.Count-1)]);
           // this.Cancel(i, 4);
        }
    }
    public List<int> CreatePropTable(int w)
    {
        List<int> list = new List<int>();
        for (int i = 0, z = w, a = 0; i< 10;i++,z--,a++)
        {
            for(int j=0;j<15-Math.Abs(a-z); j++)
            {
                Console.Write(i);
                list.Add(i);

            }
            Console.WriteLine();
        }
        return list;
    }


}


class WinImport : Form
{
    public  String plik;
    public Label lbl = new Label();
    public TextBox tBox = new TextBox();
    public Button btn = new Button();
    public Sudoku sudo;
    public  int[,] ImportTab = new int[9,9];
    public WinImport()
    {

        Width = 500;
        Text = "Wprowadzanie danych pliku importu";
        lbl.Top = 50;
        lbl.AutoSize = true;
        lbl.Left = 100;
        lbl.Text = "Wskaż lokalizację pliku importu";
        tBox.Top = 100;
        tBox.Left = 100;
        btn.Top = 150;
        btn.Left = 100;
        btn.Text = "Importuj";
        btn.Click += OnClick;
        //this.Disposed += OnDisposed;
        //btn.Click += MainForm.met1;
        Controls.Add(lbl);
        Controls.Add(tBox);
        Controls.Add(btn);
        


    }

    private void OnDisposed(object sender, EventArgs ea)
    {
       // win = null;
    }

    private void OnClick(object sender, EventArgs ea)
    {
        //Sudoku sud = new Sudoku();
        plik = tBox.Text;
        if (plik == "" || plik[plik.Length - 1] != 't') 
        {
            Console.WriteLine("poza");
            //lbl.Text = "NIE wskazałaś danych do pobrania";
            return;
           
        }
        //lbl.Text = "Importuję";
        try
        {
            sudo = Sudoku.GetSudokuFromFile(plik);
        }
        catch(Exception)
        {
            Console.WriteLine("nie ma takiego pliku !!!");
            return;
        }
        ImportTab = sudo.Copy();
        this.Close();
        //Console.WriteLine(ImportTab[3, 3]);
    }
        

        //this.Wyswietl(sud);

    



}

class MainForm : Form
{
    private TextBox tb0,tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10,
        tb11, tb12, tb13, tb14, tb15, tb16, tb17, tb18, tb19, tb20,
        tb21, tb22, tb23, tb24, tb25, tb26, tb27, tb28, tb29, tb30,
        tb31, tb32, tb33, tb34, tb35, tb36, tb37, tb38, tb39, tb40,
        tb41, tb42, tb43, tb44, tb45, tb46, tb47, tb48, tb49, tb50,
        tb51, tb52, tb53, tb54, tb55, tb56, tb57, tb58, tb59, tb60,
        tb61, tb62, tb63, tb64, tb65, tb66, tb67, tb68, tb69, tb70,
        tb71, tb72, tb73, tb74, tb75, tb76, tb77, tb78, tb79, tb80;

    public TextBox[] tb = new TextBox[81];

    public Sudoku sud;






    private void OnClickOProg(object sender, EventArgs ea)
    {
        MessageBox.Show("Stworzono w Styczniu/Lutym 2017");
        
        

        


    }

    private void OnCreateNew(object sender, EventArgs ea)
    {
        Sudoku sud = Sudoku.Create();
        for (int i = 0; i < 5; i++)
        {
            sud.Recomb();
        }
        //sud.CancelAll();
        Wyswietl(sud);
    }

    private void OnExit(object sender, EventArgs ea)
    {
        Application.Exit();
        //Sudoku sud = new Sudoku();
        //sud.CreatePropTable(1);
       
        
        

    }
    /*
    private void OnInput(object sender, EventArgs ea)
    {

        MessageBox.Show("Kliknięto wewnątrz");
        List<int> l = new List<int>();
        Random rand = new Random();
        int[] tab = new int[9];
        


    }
    */

    public void Wyswietl(Sudoku s)
    {
        int cnt = 0;
        for (int i = 0; i < 9; i++)

        {
            for (int j = 0; j < 9; j++)
            {
                if (s.sudokuTab[i,j] == 0)
                    tb[cnt].Text = "";
                else
                    tb[cnt].Text = s.sudokuTab[i, j].ToString();
                cnt++;

            }
        }
    }
   
    private void Import(object sender, EventArgs ea)
    {

        //string plik = tbPlik.Text;
        //Sudoku sud;
        
        if(win==null)
        {
            Console.WriteLine("tworzę nowy obiekt");
         win = new WinImport();
            win.FormClosed += OnWinClosed;
            win.Disposed += OnWinDisposed;
            win.tBox.Text = "tu wpisz nazwę pliku";
        }
        win.Show();
        //sud = WinImport.sudo;
       // this.Wyswietl(sud);
        


    }
    
    private void OnWinClosed(object sender, EventArgs ea)
    {
       // int[,] temp = new int[9, 9];
        
        Sudoku su = new Sudoku(win.ImportTab);
        Console.WriteLine("Jestem");
        win = null;
        
        this.Wyswietl(su);
    }
    private void OnWinDisposed(object sender, EventArgs ea)
    {
        Console.WriteLine("Jestem w ONWindisposed");
        win = null;
    }


    private void Solve(object sender, EventArgs ea)
    {
        if(sud==null)
        {
            sud = new Sudoku();
            int cnt = 0;
            for (int i = 0; i < 9; i++)

            {
                for (int j = 0; j < 9; j++)

                {
                    if (tb[cnt].Text == "")
                        sud.sudokuTab[i, j] = 0;
                    else
                    sud.sudokuTab[i, j] = Int32.Parse(tb[cnt].Text);
                    cnt++;

                }
            }
        }




        sud.Check();
        if (sud.IsSolution())

            this.Wyswietl(sud);
        else
        {
            sud.DeepSearch();
            this.Wyswietl(sud);
        }
        if (!sud.IsSolution())
        {
            

            lbl.Text = "Nie znaleziono rozwiązania. Spróbuj głębszego szukania";
        }

    }
    private void DeeperSearch(object sender, EventArgs ea)
    {

        sud = new Sudoku();
        int cnt = 0;
        for (int i = 0; i < 9; i++)

        {
            for (int j = 0; j < 9; j++)

            {
                if (tb[cnt].Text == "")
                    sud.sudokuTab[i, j] = 0;
                else
                    sud.sudokuTab[i, j] = Int32.Parse(tb[cnt].Text);
                cnt++;

            }
        }
    

    sud.Check();
        if (sud.IsSolution())

            this.Wyswietl(sud);
        else
        {
            sud.DeepSearch(true);
            this.Wyswietl(sud);
        }
        if (!sud.IsSolution())
            lbl.Text = "Niestety";

    }

    private void Reset(object sender, EventArgs ea)
    {
        if (sud == null)
        {
            MessageBox.Show("sudoku już puste");
            return;

        }
        else
        {
            sud = null;
            for (int i = 0; i < 81; i++)
            {
                tb[i].Text = "";
                tb[i].BackColor = System.Drawing.Color.White;
            }
        }


    }

    private void Help(object sender, EventArgs ea)
    {
        int[,] temp = new int[9, 9];
        int los;
        int pomoc;
        List<int> emptyList = new List<int>();
        for(int i=0;i<81;i++)
        {
            if (tb[i].Text == "")
                emptyList.Add(i);
        }

        Random rand = new Random();
        los = rand.Next(emptyList.Count);
        los = emptyList[los];


        temp = sud.Copy();
        sud.Check();
        if (!sud.IsSolution())
            sud.DeepSearch();
        pomoc = sud.sudokuTab[los / 9, los % 9];
        sud.sudokuTab = sud.CopyReverse(temp);
        sud.sudokuTab[los / 9, los % 9] = pomoc;
        tb[los].Text = pomoc.ToString();
        tb[los].BackColor = System.Drawing.Color.Green;


    }


    public Button button1 = new Button();
    public Button button2 = new Button();
    public Label lbl = new Label();
    public TextBox tbPlik = new TextBox();
    public  WinImport win;
    

    public MainForm()
    {

       // if (win == null)
         //   win = new WinImport();

            TextBox[] temp = new TextBox[81] {tb0,tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10,
            tb11, tb12, tb13, tb14, tb15, tb16, tb17, tb18, tb19, tb20,
            tb21, tb22, tb23, tb24, tb25, tb26, tb27, tb28, tb29, tb30,
            tb31, tb32, tb33, tb34, tb35, tb36, tb37, tb38, tb39, tb40,
            tb41, tb42, tb43, tb44, tb45, tb46, tb47, tb48, tb49, tb50,
            tb51, tb52, tb53, tb54, tb55, tb56, tb57, tb58, tb59, tb60,
            tb61, tb62, tb63, tb64, tb65, tb66, tb67, tb68, tb69, tb70,
            tb71, tb72, tb73, tb74, tb75, tb76, tb77, tb78, tb79, tb80
        };

       
        for(int i = 0;i<81; i++)
            {
                tb[i] = temp[i];
            }
        for (int i = 0; i < 81; i++)
        {
            tb[i] = new TextBox();
        }


       
        Width = 620;
        Height = 600;
        Text = "Sudoku Solver";
        button1.Left = 100;
        button2.Left = 100;
        tbPlik.Left = 100 + button1.Width + 30;
        tbPlik.Width = 250;
        int top = 50;
        int left = 50;
        for(int i=0;i<81;i++)
        {
            if (i % 9 == 0 && i != 0)
            {
                left = 50;
                top += 35;
            }
            if (i % 27 == 0 && i != 0)
            {
                //left  +=30;
                top += 15;
            }
            if (i % 3 == 0)
            {
                left  +=15;
                //top += 20;
            }

            tb[i].Left = left;
            tb[i].Top = top;
            left += 30;
            

        }
        for (int i = 0; i < 81; i++)
        {
            tb[i].Width = 25;

        }
        
        button1.Top = top+50;
        tbPlik.Top = top + 50;
        button1.Text = "Importuj";
        button2.Text = "Rozwiąż";
        button2.Width = 100;
        button2.BackColor = System.Drawing.Color.Azure;
        button2.Top = top + 80;
        button1.Click += Import;
        button2.Click += Solve;
        lbl.Text = "Witam";
        lbl.Top = ClientSize.Height - 60;
        lbl.ForeColor = System.Drawing.Color.Red;
        lbl.Font = new System.Drawing.Font("Arial", 12);
        
        

        MainMenu mm = new MainMenu();
        MenuItem operacje = new MenuItem("Operacje");
        MenuItem opImport = new MenuItem("Import");
        MenuItem opSolve = new MenuItem("Rozwiąż");
        MenuItem opHelp = new MenuItem("Podpowiedz");
        MenuItem opDP = new MenuItem("Głębsze Szukanie");



        MenuItem opReset = new MenuItem("Resetuj");
        MenuItem Create = new MenuItem("Tworzenie");
        MenuItem opCreateNew = new MenuItem("Twórz nowe");
        MenuItem oProg = new MenuItem("O programie");
        MenuItem quit = new MenuItem("Wyjdź");
        oProg.Click += OnClickOProg;
        quit.Click += OnExit;
        opImport.Click += Import;
        opSolve.Click += Solve;
        opReset.Click += Reset;
        opHelp.Click += Help;
        opDP.Click += DeeperSearch;
        opCreateNew.Click += OnCreateNew;


        operacje.MenuItems.Add(opImport);
        operacje.MenuItems.Add(opSolve);
        operacje.MenuItems.Add(opHelp);
        operacje.MenuItems.Add(opDP);
        operacje.MenuItems.Add(opReset);
        Create.MenuItems.Add(opCreateNew);
        mm.MenuItems.Add(operacje);
        mm.MenuItems.Add(Create);
        mm.MenuItems.Add(oProg);
        mm.MenuItems.Add(quit);
        
        Menu = mm;

       /* for (int i = 0; i < 81; i++)
        {
            tb[i].TextChanged += OnInput;

        }*/

        for (int i = 0; i < 81; i++)
        {
            Controls.Add(tb[i]);

        }

        //Controls.Add(button1);
        Controls.Add(button2);
        Controls.Add(lbl);
        //Controls.Add(tbPlik);

    }

    
    
}
class Program
{
    
    public static void Main()
    {
        MainForm mf = new MainForm();
        Application.Run(mf);
    }
}

