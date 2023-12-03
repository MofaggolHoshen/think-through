#include <bits/stdc++.h>
using namespace std;

int main()
{
    int t;
    cin >> t;

    for (int i = 0; i < t; i++)
    {
        int n;
        cin >> n;
        vector<int> ar(n);
        for (int j = 0; j < n; j++)
        {
            cin >> ar[j];
        }

        bool notSorted = false;
        for (int k = 0; k < n - 1; k++)
        {
            for (int l = k + 1; l < n; l++)
            {
                if (ar[k] <= ar[l])
                {
                    continue;
                }
                else
                {
                    notSorted = true;
                    break;
                }
            }

            if (notSorted)
                break;
        }

        if (notSorted)
            cout << "NO" << endl;
        else
            cout << "YES" << endl;
    }

    return 0;
}