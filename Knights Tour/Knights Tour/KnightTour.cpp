#include "KnightTour.h"
#include <time.h>
#include <stdlib.h> 

KnightTour::KnightTour()
{
}

KnightTour::KnightTour(int _size)
{
	size = _size;
	solution = new int[size*size];
	cx = new int[8]{ 1, 1, 2, 2, -1, -1, -2, -2 };
	cy = new int[8]{ 2, -2, 1, -1, 2, -2, 1, -1 };
}

bool KnightTour::limits(int x, int y)
{
	return ((x >= 0 && y >= 0) && (x < size  && y < size));
}

bool KnightTour::isempty(int a[], int x, int y)
{
	return (limits(x, y)) && (a[y*size + x] < 0);
}

int KnightTour::getDegree(int a[], int x, int y)
{
	int count = 0;
	for (int i = 0; i < size; ++i)
		if (isempty(a, (x + cx[i]), (y + cy[i])))
			count++;

	return count;
}

bool KnightTour::nextMove(int a[], int *x, int *y)
{
	int min_deg_idx = -1, c, min_deg = (size + 1), nx, ny;

	int start = rand() % size;
	for (int count = 0; count < size; ++count)
	{
		int i = (start + count) % size;
		nx = *x + cx[i];
		ny = *y + cy[i];
		if ((isempty(a, nx, ny)) &&
			(c = getDegree(a, nx, ny)) < min_deg)
		{
			min_deg_idx = i;
			min_deg = c;
		}
	}

	if (min_deg_idx == -1)
		return false;

	nx = *x + cx[min_deg_idx];
	ny = *y + cy[min_deg_idx];

	a[ny*size + nx] = a[(*y)*size + (*x)] + 1;

	*x = nx;
	*y = ny;

	return true;
}

bool KnightTour::neighbour(int x, int y, int xx, int yy)
{
	for (int i = 0; i < size; ++i)
		if (((x + cx[i]) == xx) && ((y + cy[i]) == yy))
			return true;

	return false;
}

bool KnightTour::findClosedTour(int startX, int startY, bool closestWay)
{
	for (int i = 0; i < size*size; ++i)
		solution[i] = -1;

	int sx = startX;
	int sy = startY;
	int x = sx, y = sy;
	solution[y*size + x] = 1;

	for (int i = 0; i < size*size - 1; ++i)
		if (nextMove(solution, &x, &y) == 0)
			return false;

	if (closestWay)
	{
		if (!neighbour(x, y, sx, sy))

			return false;
	}

	return true;
}

KnightTour::~KnightTour()
{
}