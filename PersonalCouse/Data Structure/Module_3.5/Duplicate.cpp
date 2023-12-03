#include <bits/stdc++.h>
using namespace std;

int main()
{
    int n;
    bool falg = false;
    cin >> n;
    vector<int> v(n);

    for (int i = 0; i < n; i++)
    {
        cin >> v[i];
    }

    for (int i = 0; i < n; i++)
    {
        int count = 0;
        for (int val : v)
        {
            if (val == v[i])
                count++;
        }

        if (count > 1)
        {
            falg = true;
            break;
        }
    }

    if (falg)
        cout << "YES";
    else
        cout << "NO";

    // int n2 = v.size();
    // vector<int> ans;
    // for (int i = 0; i < n2; i++)
    // {
    //     int x = abs(v[i]);
    //     x--;
    //     if (v[x] < 0)
    //         ans.push_back(x + 1);
    //     else
    //         v[x] *= -1;
    // }
    // for (int vv : v)
    // {
    //     cout << vv << " ";
    // }
    // cout << endl;
    // for (int vv : ans)
    // {
    //     cout << vv << " ";
    // }

    return 0;
}