using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
class Playfer
{

    //Размеры биграммы, будут меняться в зависимости от языка кодирвания
    private int _rowSize;
    private int _colSize;

    private int _allSize;
    private string _keyWord = "";
    //Для проверки использованных букв в ключевом слове
    private bool[] _isLetter;
    //Алфавит для создания биграммы
    Dictionary<char, int> lettersMapOne = new Dictionary<char, int>();
    Dictionary<int, char> lettersMapTwo = new Dictionary<int, char>();

    //Массив для биграммы
    private char[,] _bigramma;
    public Playfer(string value = "eng")
    {
        if (value == "eng")
        {
            _rowSize = 5;
            _colSize = 5;
        }
        else if (value == "ru")
        {
            _rowSize = 8;
            _colSize = 4;
        }
        else
        {
            throw new ArgumentException("Неправильный параметр языка кодировки");
        }
        _bigramma = new char[_colSize, _rowSize];
        _allSize = _rowSize * _colSize + 1;
        _isLetter = new bool[_allSize];
        // Заполняем буквами и номерами
        for (int i = 0; i < _allSize; i++)
        {
            if (value == "eng")
            {
                char letter = (char)('a' + i);
                lettersMapOne.Add(letter, i);
                lettersMapTwo.Add(i, letter);
            }
            else
            {
                char letter = (char)('а' + i);
                lettersMapOne.Add(letter, i);
                lettersMapTwo.Add(i, letter);
            }
        }
    }

    public string keyWord
    {
        get
        {
            return _keyWord;
        }
        set
        {
            if (value.Length < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            char previousLet = ' ';
            string result = "";
            int numCurLet = ' ';
            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] != previousLet || previousLet == ' ')
                {
                    result += value[i];
                    previousLet = value[i];
                }
                lettersMapOne.TryGetValue(result[result.Length - 1], out numCurLet);
                if (!_isLetter[numCurLet])
                {
                    _isLetter[numCurLet] = true;
                }
            }

            _keyWord = result;

            int count = 0;
            int countTwo = 0;
            for (int i = 0; i < _rowSize; i++)
            {
                for (int j = 0; j < _colSize; j++)
                {
                    if (_keyWord.Length > count)
                    {
                        _bigramma[i, j] = _keyWord[count];
                        count++;
                    }
                    else
                    {
                        while (_isLetter[countTwo]) countTwo++;
                        if (lettersMapTwo[countTwo] == 'j') countTwo++;
                        _bigramma[i, j] = lettersMapTwo[countTwo];
                        countTwo++;
                    }
                }
            }
        }
    }

    public void printBigramm()
    {
        for (int i = 0; i < _rowSize; i++)
        {
            for (int j = 0; j < _colSize; j++)
            {
                Console.Write($"| {this._bigramma[i, j]} ");
            }
            Console.WriteLine('|');

        }
    }

    public string coding(string str)
    {
        Dictionary<char, (int x, int y)> wordDict = new Dictionary<char, (int x, int y)>();
        string result = "";
        //Подготовка слова в кодированию (между двумя одиниковыми буквами x или не кратное слово, то добавляем x)  
        string preparingStr = "";
        char previousLet = ' ';
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] != previousLet || previousLet == ' ')
            {
                preparingStr += str[i];
                previousLet = str[i];
                if (!wordDict.ContainsKey(str[i])) wordDict.Add(str[i], (0, 0));
            }
            else
            {
                preparingStr += 'x';
                preparingStr += str[i];
                if (!wordDict.ContainsKey('x')) wordDict.Add('x', (0, 0));
                if (!wordDict.ContainsKey(str[i])) wordDict.Add(str[i], (0, 0));

            }
        }
        if (preparingStr.Length % 2 != 0)
        {
            preparingStr += 'x';
            if (!wordDict.ContainsKey('x')) wordDict.Add('x', (0, 0));
        }

        findIndexesLetters(ref wordDict);

        for (int i = 0, j = 1; j < preparingStr.Length; i += 2, j += 2)
        {
            (int iRowOne, int iColOne) = wordDict[preparingStr[i]];
            (int iRowTwo, int iColTwo) = wordDict[preparingStr[j]];

            if (iRowOne == iRowTwo)
            {
                if (iColTwo == _colSize - 1)
                {
                    iColOne++;
                    iColTwo = 0;

                }
                else
                {
                    iColOne++;
                    iColTwo++;
                }
            }
            else if (iColOne == iColTwo)
            {
                if (iRowTwo == _rowSize - 1)
                {
                    iRowOne++;
                    iRowTwo = 0;
                }
                else
                {
                    iRowOne++;
                    iRowTwo++;
                }
            }
            else
            {
                int temp = iColOne;
                iColOne = iColTwo;
                iColTwo = temp;
            }

            result += _bigramma[iRowOne, iColOne];
            result += _bigramma[iRowTwo, iColTwo];
        }
        return result;
    }

    public string decoding(string str)
    {
        Dictionary<char, (int x, int y)> wordDict = new Dictionary<char, (int x, int y)>();
        string result = "";
        //Подготовка слова в кодированию (между двумя одиниковыми буквами x или не кратное слово, то добавляем x)  
        for (int i = 0; i < str.Length; i++)
        {
            if (!wordDict.ContainsKey(str[i])) wordDict.Add(str[i], (0, 0));
        }


        findIndexesLetters(ref wordDict);

        for (int i = 0, j = 1; j < str.Length; i += 2, j += 2)
        {
            (int iRowOne, int iColOne) = wordDict[str[i]];
            (int iRowTwo, int iColTwo) = wordDict[str[j]];

            if (iRowOne == iRowTwo)
            {
                if (iColTwo == 0)
                {
                    iColOne--;
                    iColTwo = _colSize - 1;

                }
                else
                {
                    iColOne--;
                    iColTwo--;
                }
            }
            else if (iColOne == iColTwo)
            {
                if (iRowTwo == 0)
                {
                    iRowOne--;
                    iRowTwo = _rowSize - 1;
                }
                else
                {
                    iRowOne--;
                    iRowTwo--;
                }
            }
            else
            {
                int temp = iColTwo;
                iColTwo = iColOne;
                iColOne = temp;
            }

            result += _bigramma[iRowOne, iColOne];
            result += _bigramma[iRowTwo, iColTwo];
        }
        return result;
    }
    private void findIndexesLetters(ref Dictionary<char, (int x, int y)> wordDict)
    {
        for (int i = 0; i < _rowSize; i++)
        {
            for (int j = 0; j < _colSize; j++)
            {
                if (wordDict.ContainsKey(_bigramma[i, j]))
                {
                    wordDict[_bigramma[i, j]] = (i, j);
                }
            }
        }
    }
}

class Test
{
    static void Main(string[] args)
    {
        Playfer test = new Playfer();
        test.keyWord = "commander";
        test.printBigramm();
        string t = test.coding("student");
        test.decoding(t);
        // Console.WriteLine(test.keyWord);

    }
}
