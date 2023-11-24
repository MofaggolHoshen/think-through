#include <bits/stdc++.h>
using namespace std;

int main()
{
    int t;
    cin >> t;
    for (int test = 0; test < t; test++)
    {
        int n;
        cin >> n;
        if (n % 2 == 0)
        {
            int oddCount = 0;
            for (int i = 0; i < n; i++)
            {
                int num;
                cin >> num;
                if (num % 2 != 0)
                    oddCount++;
            }

            int half = n / 2;

            int oddStep = abs(half - oddCount);

            cout << oddStep << endl;
        }
        else
        {
            cout << "-1" << endl;
        }
    }

    return 0;
}