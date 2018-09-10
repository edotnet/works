#pragma once

class Board
{
public:
	Board();
	~Board();
	Board(int size, int vertSize, int horSize);
	void printBoard();
	int _size;
	int _vertSize;
	int _horSize;
};