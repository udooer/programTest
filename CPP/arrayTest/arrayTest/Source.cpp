#include <iostream>
using namespace std;

int main() {
	int test[10];
	memset(test, int(-1), 10);
	for (int i=0;i<10;i++)
		cout << test[i] << ' ';
	return 0;
}