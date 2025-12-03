using System;
using System.Collections.Generic;

/// <summary>
/// Hilfsklassen für Schiffe-Versenken Minigame
/// </summary>

public class Board
{
    public char[,] Grid;  // Spielfeld
    public int Size;      // Größe (6 oder 8)
    
    public Board(int size)
    {
        Size = size;
        Grid = new char[size, size];
        
        // Initialisiere mit Wasser
        for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
                Grid[i, j] = '~';
    }
    
    public void PlaceShip(Ship ship)
    {
        int row = ship.Row;
        int col = ship.Col;
        
        for (int i = 0; i < ship.Size; i++)
        {
            if (ship.IsHorizontal)
                Grid[row, col + i] = '■';
            else
                Grid[row + i, col] = '■';
        }
    }
    
    public bool IsValidPlacement(int row, int col, int shipSize, bool isHorizontal)
    {
        // Prüfe ob Schiff aufs Feld passt
        if (isHorizontal && col + shipSize > Size) return false;
        if (!isHorizontal && row + shipSize > Size) return false;
        
        // Prüfe ob Position frei ist
        for (int i = 0; i < shipSize; i++)
        {
            int r = isHorizontal ? row : row + i;
            int c = isHorizontal ? col + i : col;
            if (Grid[r, c] != '~') return false;
        }
        
        return true;
    }
}

public class Ship
{
    public int Size;           // Größe des Schiffs
    public int Row, Col;       // Position
    public bool IsHorizontal;  // Richtung
    public int Hits;           // Anzahl Treffer
    
    public Ship(int size)
    {
        Size = size;
        Hits = 0;
    }
    
    public bool IsSunk()
    {
        return Hits >= Size;
    }
}