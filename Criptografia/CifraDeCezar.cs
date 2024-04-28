namespace Criptografia;
public static class CifraDeCesar
{

  public static int Key { get; set; } = 14;
  public static List<char> CharsRange { get; set; } =
  [
    'a', 'b', 'c', 'd', 'e', 'f',
    'g', 'h', 'i', 'j', 'k', 'l',
    'm', 'n', 'o', 'p', 'q', 'r',
    's', 't', 'u', 'v', 'w', 'x',
    'y', 'z', 'A', 'B', 'C', 'D',
    'E', 'F', 'G', 'H', 'I', 'J',
    'K', 'L', 'M', 'N', 'O', 'P',
    'Q', 'R', 'S', 'T', 'U', 'V',
    'W', 'X', 'Y', 'Z'
  ];

  // public static CifraDeCesar(int key, List<char> charsRange)
  // {
  //   Key = key;
  //   CharsRange = charsRange;
  // }
  // public static CifraDeCesar(int key)
  // {
  //   Key = key;
  // }

  public static string Criptografar(string text)
  {
    var chars = text.ToCharArray();
    int length = chars.Count();

    for (int i = 0; i < length; i++)
    {
      if(chars[i] == ' ')
        continue;

      int indexNewChar = CharsRange.FindIndex(x => x == chars[i]);
      indexNewChar = ParseIndexPositive(indexNewChar + Key);
      chars[i] = CharsRange[indexNewChar];
    }

    return new string(chars);
  }

  public static string Descriptografar(string text)
  {
    var chars = text.ToCharArray();
    int length = chars.Count();

    for (int i = 0; i < length; i++)
    {
      if(chars[i] == ' ')
        continue;

      int indexNewChar = CharsRange.FindIndex(x => x == chars[i]);
      indexNewChar = ParseIndexNegative(indexNewChar - Key);
      chars[i] = CharsRange[indexNewChar];
    }

    return new string(chars);
  }

  private static int ParseIndexPositive(int index)
  {
    while(index >= CharsRange.Count)
    {
      index -= CharsRange.Count;
    }

    return index;
  }
  private static int ParseIndexNegative(int index)
  {
    while(index < 0)
    {
      index += CharsRange.Count;
    }

    return index;
  }
}
