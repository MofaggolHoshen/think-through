#include <bits/stdc++.h>
using namespace std;

int main()
{
    int n;
    cin >> n;
    long long ar[n];
    long long prx[n];
    for (int i = 0; i < n; i++)
    {
        cin >> ar[i];

        if (i == 0)
            prx[i] = ar[i];
        else
            prx[i] = ar[i] + prx[i - 1];
    }

    for (int i = n - 1; i >= 0; i--)
    {
        cout << prx[i] << " ";
    }

    return 0;
}