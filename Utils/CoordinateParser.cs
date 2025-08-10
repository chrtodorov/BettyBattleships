using System.Globalization;
using BettyBattleships.Models;

namespace BettyBattleships.Utils;

public static class CoordinateParser
{
    // Accepts formats like A1, B7, j10 (case-insensitive); trims spaces
    public static bool TryParse(string? input, out Coordinate coordinate, int boardSize = 10)
    {
        coordinate = default;
        if (string.IsNullOrWhiteSpace(input)) return false;

        var trimmed = input.Trim().ToUpperInvariant();
        if (trimmed.Length < 2 || trimmed.Length > 3) return false;

        var rowChar = trimmed[0];
        if (rowChar < 'A' || rowChar >= 'A' + boardSize) return false;

        var colPart = trimmed[1..];
        if (!int.TryParse(colPart, NumberStyles.None, CultureInfo.InvariantCulture, out int col)) return false;
        if (col < 1 || col > boardSize) return false;

        int row = rowChar - 'A';
        int colIndex = col - 1;
        coordinate = new Coordinate(row, colIndex);
        return true;
    }
}
