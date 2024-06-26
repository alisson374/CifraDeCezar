﻿namespace Criptografia;
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
    'W', 'X', 'Y', 'Z', ' ', '1',
    '2', '3', '4', '5', '6', '7',
    '8', '9', '0', '*', '&', ',',
    '.', '/', '?', '!', '~', '"',
    '-', '>', '<', '{', '}','@'
  ];

  public static string Criptografar(string text)
  {
    var chars = text.ToCharArray();
    int length = chars.Length;

    for (int i = 0; i < length; i++)
    {
      int indexNewChar = CharsRange.FindIndex(x => x == chars[i]);
      indexNewChar = ParseIndexPositive(indexNewChar);
      chars[i] = CharsRange[indexNewChar];
    }

    return new string(chars);
  }

  public static string Descriptografar(string text)
  {
    var chars = text.ToCharArray();
    int length = chars.Length;

    for (int i = 0; i < length; i++)
    {
      int indexNewChar = CharsRange.FindIndex(x => x == chars[i]);
      indexNewChar = ParseIndexNegative(indexNewChar);
      chars[i] = CharsRange[indexNewChar];
    }

    return new string(chars);
  }

  private static int ParseIndexPositive(int index) =>
    (index + (Key % CharsRange.Count) + CharsRange.Count) % CharsRange.Count;

  private static int ParseIndexNegative(int index) =>
    (index + (-Key % CharsRange.Count) + CharsRange.Count) % CharsRange.Count;
}
