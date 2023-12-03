#include <bits/stdc++.h>
using namespace std;

int main()
{
    int n;
    cin >> n;

    vector<int> v;
    vector<int> v2;

    for (int i = 0; i < n; i++)
    {
        int k;
        cin >> k;
        v.push_back(k);
    }

    for (int i = 0; i < n; i++)
    {
        int k;
        cin >> k;
        v2.push_back(k);
    }

    v2.insert(v2.end(), v.begin(), v.end());

    for (int x : v2)
    {
        cout << x << " ";
    }
    return 0;
}