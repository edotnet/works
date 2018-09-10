#include <iostream>
#include <time.h>
#include <string>
#include <windows.h>
#include "KnightTour.h"
#include "Board.h"

using namespace std;

static string *moves;

KnightTour kn(8);
Board b(kn.size, 2, 4);

int findNum(int x, int a[])
{
	for (size_t i = 0; i < kn.size*kn.size; i++)
	{
		if (a[i] == x)
		{
			return i;
		}
	}
	return -1;
}

void gotoxy(int x, int y)
{
	COORD coord = { x, y };
	SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE), coord);
}

void printSolution(KnightTour kt, Board b)
{
	moves = new string[kt.size*kt.size];
	for (int i = 0; i < kt.size; ++i)
	{
		for (int j = 0; j < kt.size; ++j)
		{
			int num = findNum(i*kt.size + j + 1, kt.solution);
			gotoxy((num % kt.size) * b._horSize + 1, ((int)num / kt.size) * b._vertSize + 1);
			moves[i*kt.size + j] = to_string(i*kt.size + j + 1) + "(" + to_string(num%kt.size + 1) + "," + to_string((int)num / kt.size + 1) + ")";
			cout << i * kt.size + j + 1;
			Sleep(250);
		}
	}

	cout << "\n" << endl;
	gotoxy(0, b._size*b._vertSize + 7);

	for (size_t i = 0; i < kt.size*kt.size; i++)
	{
		cout << "| " << moves[i] << " ";
	}
	cout << "|\n\n";

}

int main()
{
	int x, y;

	b.printBoard();
	cout << "Start X = ";
	cin >> x;
	cout << endl << "Start Y = ";
	cin >> y;
	cout << endl << endl;

	if (x > 0 && x <= kn.size && y > 0 && y <= kn.size)
	{
		while (!kn.findClosedTour(x - 1, y - 1, false))
		{
		}
		printSolution(kn, b);
	}
	else
	{
		cout << "Incorrect coordinates" << endl;
	}

	system("pause");
	return 0;
}