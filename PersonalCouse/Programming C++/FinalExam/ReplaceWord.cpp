#include <bits/stdc++.h>
using namespace std;

int main()
{

    int t;
    cin >> t;

    for (int i = 0; i < t; i++)
    {
        string s, x;
        cin >> s >> x;

        while (s.find(x) != -1)
        {
            int index = s.find(x);

            int len = x.length();

            s.replace(index, len, "#");
        }

        cout << s << endl;
    }

    return 0;
}