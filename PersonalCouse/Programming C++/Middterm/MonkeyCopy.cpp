#include <bits/stdc++.h>
using namespace std;

int main()
{

    char ar[100000];
    
    while (cin.getline(ar,100000))
    {
        sort(ar, ar + strlen(ar));
        cout << ar <<endl; 
    }
}