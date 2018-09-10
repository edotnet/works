#include "Board.h"
#include <string>
#include <iostream>

using namespace std;

Board::Board()
{
}

Board::Board(int size, int vertSize, int horSize)
{
	_size = size;
	_vertSize = vertSize;
	_horSize = horSize;
}

void Board::printBoard()
{
	string s1;
	string s2;

	s1.append(_horSize - 1, '_');
	s2.append(_horSize - 1, ' ');

	for (size_t i = 0; i < _vertSize* _size; i++)
	{
		if (i == 0) {
			for (size_t j = 0; j < _size * _horSize; j++)
			{
				cout << "_";
			}
			cout << endl;
		}
		else if (i%_vertSize == 0)
		{
			for (size_t j = 0; j < _size; j++)
			{
				cout << "|" << s1;
			}
			cout << "|" << i / _vertSize << endl;
		}
		else
		{
			for (size_t j = 0; j < _size; j++)
			{
				cout << "|" << s2;
			}
			cout << "|" << endl;
		}
	}
	for (size_t j = 0; j < _size; j++)
	{
		cout << "|" << s1;
	}
	cout << "|" << _size << endl;
	for (size_t i = 1; i <= _size; i++)
	{
		cout << s2 << i;
	}
	cout << "\n" << endl;
}

Board::~Board()
{
}
