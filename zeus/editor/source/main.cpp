#include <iostream>
#include "../include/editor.h"

using namespace std;

int main()
{
	cout << "zeus editor start." << endl;
	zeus::editor zeus_editor;
	zeus_editor.run();
	
	return 0;
}
