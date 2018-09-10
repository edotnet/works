class KnightTour
{
public:
	KnightTour();
	~KnightTour();
	bool findClosedTour(int, int, bool);
	KnightTour(int);
	int size;
	int* solution;
private:
	bool limits(int, int);
	bool isempty(int[], int, int);
	int getDegree(int[], int, int);
	bool nextMove(int[], int *, int*);
	bool neighbour(int x, int y, int xx, int yy);
	int* cx;
	int* cy;
};