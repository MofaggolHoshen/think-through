#include <bits/stdc++.h>
using namespace std;

int main()
{
    int t;
    cin >> t;
    for (int test = 0; test < t; test++)
    {
        int n;
        char ch;
        cin >> n >> ch;

        string s(n, ch);

        for (char c : s)
        {
            cout << c << " ";
        }
        cout << endl;
    }

    
    return 0;
}