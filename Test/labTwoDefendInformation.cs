class Gammer
{
    private string _resText = "";
    private string _inText = "";
    private string _gammaText = "";
    private int _size = 32;
    Dictionary<char, int> _alphabetLetNum = new Dictionary<char, int>();
    Dictionary<int, char> _alphabetNumLet = new Dictionary<int, char>();
    Dictionary<char, int> result;

    public string codText
    {
        get
        {
            return _resText;
        }
    }
    public void filAlphabet()
    {

        for (int i = 0, j = 0; i <= _size; i++)
        {
            if (i == _size)
            {
                _alphabetLetNum.Add(' ', j);
                _alphabetNumLet.Add(j, ' ');
                j++;
            }
            else
            {
                char letter = (char)('а' + i);
                if (letter == 'ъ')
                {
                    continue;
                }
                _alphabetLetNum.Add(letter, j);
                _alphabetNumLet.Add(j, letter);
                j++;
            }
        }
    }



    public string gamma
    {
        set
        {
            if (_alphabetLetNum.Count == 0)
                filAlphabet();
            _gammaText = value;
        }
    }

    public string coding(string inText)
    {
        int numLet;
        result = new Dictionary<char, int>();
        for (int i = 0, count = 0; i < inText.Length; i++, count++)
        {
            if (count == _gammaText.Length) count = 0;

            numLet = _alphabetLetNum[inText[i]] ^ _alphabetLetNum[_gammaText[count]];
            _resText += _alphabetNumLet[numLet];

            if (!result.ContainsKey(_alphabetNumLet[numLet]))
                result.Add(_alphabetNumLet[numLet], numLet);
            Console.WriteLine($"{_alphabetNumLet[numLet]}, {numLet}");
        }
        // Console.WriteLine(_resText);
        return _resText;
    }

    public string decoding(string text)
    {
        string decText = "";
        int numLet;
        for (int i = 0, count = 0; i < text.Length; i++, count++)
        {
            if (count == _gammaText.Length) count = 0;
            numLet = _alphabetLetNum[text[i]] ^ _alphabetLetNum[_gammaText[count]];
            decText += _alphabetNumLet[numLet];
        }
        return decText;
    }
}
class Lab
{
    static void Main(string[] args)
    {
        Gammer test2 = new Gammer();
        string inText = "нижегородский государственный политехнический университет";
        string inGamma = "любого размера может быть гамма чем больше тем устойчивее будет кодирование";
        test2.gamma = inGamma;
        string codText = test2.coding(inText);
        Console.WriteLine($"Кодируемый текст: '{inText}'");
        Console.WriteLine($"Закодированный текст: '{codText}'");

        string decodText = test2.decoding(codText);

        Console.WriteLine($"Раскодированный текст: '{decodText}'");

    }
}
